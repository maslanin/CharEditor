using System;
using System.Text;
using System.Windows.Forms;

namespace CharEditor
{
    public partial class Form1 : Form
    {
        readonly Class0 class0 = new Class0();
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string fn = openFileDialog1.FileName;
            class0.str = fn; // сохраним путь к файлу
            var MyIni = new IniFile(@fn);
            saveToolStripMenuItem.Enabled = true;

            // верний ряд
            oplatadate.Text = MyIni.Read("oplatadate", "time"); // дата оплаты
            var fa = MyIni.Read("pass", "pass");
            flag_auto.Checked = (fa == "1") ? true : false; // запускать или нет авто
            // для бэкапа
            fa = MyIni.Read("oldgold", "time");
            class0.oldgold = Int64.Parse(fa);
            fa = MyIni.Read("seanstime", "time");
            class0.seanstime = Int64.Parse(fa);
            fa = MyIni.Read("oldexp", "time");
            class0.oldexp = Int64.Parse(fa);
            fa = MyIni.Read("oldlvl", "time");
            class0.oldlvl = Int64.Parse(fa);
            fa = MyIni.Read("oldexptolvl", "time");
            class0.oldexptolvl = Int64.Parse(fa);

            login.Text = MyIni.Read("vinilogin", "pass"); // логин
            pass.Text = MyIni.Read("vinipass", "pass"); // пароль
            email.Text = MyIni.Read("viniemail", "pass"); // e-mail
            fa = MyIni.Read("viniemailonoff", "pass");
            emailonoff.Checked = (fa == "1") ? true : false; // офать ли по стаме (54:00)
            viniPapkaSoSkriptom.Text = MyIni.Read("viniPapkaSoSkriptom", "nastrojki"); // папка с маршрутом
            fa = MyIni.Read("viniSTORONAVZGLJADA", "nastrojki"); // где искать мобов, спереди, сзади, весь экран
            if (fa == "0")
                STORONAVZGLJADA.Text = "Вперед";
            else if (fa == "1")
                STORONAVZGLJADA.Text = "Назад";
            else
                STORONAVZGLJADA.Text = "Весь экран";
            uvidelwdet.Text = MyIni.Read("viniuvidelwdet", "nastrojki"); // сколько секунд ждет моба
            obzorwagov.Text = MyIni.Read("viniobzorwagov", "nastrojki"); // на сколько шагов смотреть

            // левый столбик
            world.Text = MyIni.Read("viniworld", "pass"); // мир
            nomerstamini.Text = MyIni.Read("vininomerstamini", "pass"); // номер стамины
            nomeroknatiba.Text = MyIni.Read("vininomeroknatiba", "nastrojki"); // номер окна тибки (для заголовка)
            koordinataX.Text = MyIni.Read("vinikoordinataX", "nastrojki"); // координаты окна
            koordinataY.Text = MyIni.Read("vinikoordinataY", "nastrojki"); // координаты окна
            fa = MyIni.Read("vinizapuskatjsleduwejskri", "nastrojki");
            zapuskatjsleduwejskri.Checked = (fa == "1") ? true : false; // запускать следущего чара или ждать своей стамы
            fa = MyIni.Read("vininocheckstam", "nastrojki");
            vininocheckstam.Checked = (fa == "1") ? true : false; // офать ли по стаме (54:00)
            starijskript.Text = MyIni.Read("vinistarijskript", "nastrojki"); // название предыдущего скрипта
            sleduwijskript.Text = MyIni.Read("vinisleduwijskript", "nastrojki"); // название следующего скрипта
            fa = MyIni.Read("viniallhiljatsa", "nastrojki");
            viniallhiljatsa.Checked = (fa == "1") ? true : false; // вкл/выкл хеал спелл
            fa = MyIni.Read("viniavtomag", "nastrojki");
            viniavtomag.Checked = (fa == "1") ? true : false; // вкл/выкл атак спелл
            fa = MyIni.Read("vinilongspell", "nastrojki");
            vinilongspell.Checked = (fa == "1") ? true : false; // вкл/выкл спелл на 3 шага
            fa = MyIni.Read("vinibuff", "nastrojki");
            buffonoff.Checked = (fa == "1") ? true : false; // вкл/выкл бафф
            fa = MyIni.Read("vinialveistoponof", "nastrojki");
            vinialveistoponof.Checked = (fa == "on") ? true : false; // поверх всех окон он/офф

            // блок здоровья
            vini50php.Value = -1 * Int32.Parse(MyIni.Read("vini50php", "nastrojki")); // начало стопа по хп
            vini100php.Value = -1 * Int32.Parse(MyIni.Read("vini100php", "nastrojki")); // конец стопа по хп
            viniusepivos.Value = -1 * Int32.Parse(MyIni.Read("viniusepivos", "nastrojki")); // бухнуть на таком хп
            viniothodhp.Value = -1 * Int32.Parse(MyIni.Read("viniothodhp", "nastrojki")); // отойти по хп если стоит на ком то
            vinikordoff.Value = -1 * Int32.Parse(MyIni.Read("vinikordoff", "nastrojki")); // офнуть на таком хп
            vinihphealspell.Value = -1 * Int32.Parse(MyIni.Read("vinihphealspell", "nastrojki")); // юзнуть книжку на таком хп
            vinihpforleftskill.Value = -1 * Int32.Parse(MyIni.Read("vinihpforleftskill", "nastrojki")); // хп для левого скилла
            vinihpforrightskill.Value = -1 * Int32.Parse(MyIni.Read("vinihpforrightskill", "nastrojki")); // хп для правого скилла

            // блок маны
            vinimana30.Value = -1 * Int32.Parse(MyIni.Read("vinimana30", "nastrojki")); // начало стопа по мане
            vinimana50.Value = -1 * Int32.Parse(MyIni.Read("vinimana50", "nastrojki")); // конец стопа по мане
            vinimana0.Value = -1 * Int32.Parse(MyIni.Read("vinimana0", "nastrojki")); // бухнуть по мане
            viniminmanaspell.Value = -1 * Int32.Parse(MyIni.Read("viniminmanaspell", "nastrojki")); // минимум маны для атак спелла
            viniminmanaalhil.Value = -1 * Int32.Parse(MyIni.Read("viniminmanaalhil", "nastrojki")); // минимум маны для хеал спелла
            viniminhpmobaspell.Value = -1 * Int32.Parse(MyIni.Read("viniminhpmobaspell", "nastrojki")); // минимум хп моба для атак спелла
            vinimanaforleftskill.Value = -1 * Int32.Parse(MyIni.Read("vinimanaforleftskill", "nastrojki")); // минимум маны для левого скилла
            vinimanaforrightskill.Value = -1 * Int32.Parse(MyIni.Read("vinimanaforrightskill", "nastrojki")); // минимум маны для правого скилла

            // блок пива
            fa = MyIni.Read("viniusepivohponoff", "nastrojki");
            viniusepivohponoff.Checked = (fa == "1") ? true : false; // пьем ли вообще пиво
            vinikakoepiv.Text = MyIni.Read("vinikakoepiv", "nastrojki"); // название IMG с пивом
            fa = MyIni.Read("vinipivopuhujkakoe", "nastrojki");
            vinipivopuhujkakoe.Checked = (fa == "1") ? true : false; // пьем любое пиво
            fa = MyIni.Read("viniusepivomanaonoff", "nastrojki");
            viniusepivomanaonoff.Checked = (fa == "1") ? true : false; // пьем ли вообще пиво mana
            vinikakoepivmana.Text = MyIni.Read("vinikakoepivmana", "nastrojki"); // название IMG с пивом
            fa = MyIni.Read("vinipivopuhujkakoemana", "nastrojki");
            vinipivopuhujkakoemana.Checked = (fa == "1") ? true : false; // пьем любое пиво

            // блок скиллов
            fa = MyIni.Read("viniAtackSkillONOFF", "nastrojki"); // вкл/выкл левый скилл
            viniAtackSkillONOFF.Checked = (fa == "1") ? true : false;
            fa = MyIni.Read("viniDeffSkillONOFF", "nastrojki"); // вкл/выкл правый скилл
            viniDeffSkillONOFF.Checked = (fa == "1") ? true : false;
            viniikonaAttackSkilla.Text = MyIni.Read("viniikonaAttackSkilla", "nastrojki"); // имг левого скилла
            viniikonadefskilla.Text = MyIni.Read("viniikonadefskilla", "nastrojki"); // имг правого скилла
            fa = MyIni.Read("viniuseleftskillpohp", "nastrojki"); // юзать левый скилл только если хп меньше vinihpforleftskill
            viniuseleftskillpohp.Checked = (fa == "1") ? true : false;
            fa = MyIni.Read("viniuserightskillpohp", "nastrojki"); // юзать правый скилл только если хп меньше vinihpforrightskill
            viniuserightskillpohp.Checked = (fa == "1") ? true : false;
            fa = MyIni.Read("viniuseleftskillpomane", "nastrojki"); // юзать левый скилл если мана ниже vinimanaforleftskill
            viniuseleftskillpomane.Checked = (fa == "1") ? true : false;
            fa = MyIni.Read("viniuserightskillpomane", "nastrojki"); // юзать правый скилл если мана ниже vinimanaforleftskill
            viniuserightskillpomane.Checked = (fa == "1") ? true : false;
            fa = MyIni.Read("vinionetimeskill", "nastrojki");
            vinionetimeskill.Checked = (fa == "1") ? true : false; // юзать только 1 скилл за раз

            // нижний блок
            viniVremjaWaga.Value = Int32.Parse(MyIni.Read("viniVremjaWaga", "nastrojki")); // скорость ходьбы
            vinivremenika.Text = MyIni.Read("vinivremenika", "nastrojki"); //сколько минут кач, например 117 кач 243 отдых
            fa = MyIni.Read("viniItmLuterVklju4en", "nastrojki");
            viniItmLuterVklju4en.Checked = (fa == "1") ? true : false;
            fa = MyIni.Read("viniZamenjatjPivoNaDrop", "nastrojki"); // заменять ли пиво дропом
            viniZamenjatjPivoNaDrop.Checked = (fa == "1") ? true : false;
            fa = MyIni.Read("viniperenosvinventidepot", "nastrojki"); // перенос вещей из сумки в инвент и депот
            viniperenosvinventidepot.Checked = (fa == "1") ? true : false;
            fa = MyIni.Read("vinimanakontrolvklju4on", "nastrojki"); // офать по мане
            vinimanakontrolvklju4on.Checked = (fa == "1") ? true : false;
            fa = MyIni.Read("vinivizovpeta", "nastrojki"); // юзать пета
            vinivizovpeta.Checked = (fa == "1") ? true : false;
            vinihppet.Value = Int32.Parse(MyIni.Read("vinihppet", "nastrojki")); // хп пета для оффа
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "CharEditor for AHK-BOT";
            oplatadate.Text = ""; // дата оплаты
            flag_auto.Checked = false; // запускать или нет авто
            login.Text = ""; // логин
            pass.Text = ""; // пароль
            email.Text = ""; // e-mail
            emailonoff.Checked = false;
            viniPapkaSoSkriptom.Text = ""; // папка с маршрутом
            STORONAVZGLJADA.Text = "Назад";
            uvidelwdet.Text = ""; // сколько секунд ждет моба
            obzorwagov.Text = ""; // сколько шагов смотреть вокруг

            // левый столбик
            world.Text = "1"; // мир
            nomerstamini.Text = "1"; // номер стамины
            nomeroknatiba.Text = "1"; // номер окна тибки (для заголовка)
            koordinataX.Text = "1"; // координаты окна
            koordinataY.Text = "1"; // координаты окна
            zapuskatjsleduwejskri.Checked = false; // запускать следущего чара или ждать своей стамы
            vininocheckstam.Checked = false; // офать ли по стаме (54:00)
            starijskript.Text = ""; // название предыдущего скрипта
            sleduwijskript.Text = ""; // название следующего скрипта
            viniallhiljatsa.Checked = false; // вкл/выкл хеал спелл
            viniavtomag.Checked = false; // вкл/выкл атак спелл
            vinilongspell.Checked = false; // вкл/выкл спелл на 3 шага
            buffonoff.Checked = false; // вкл/выкл бафф
            vinialveistoponof.Checked = false; // поверх всех окон он/офф

            // блок здоровья
            vini50php.Value = -14; // начало стопа по хп
            vini100php.Value = -14; // конец стопа по хп
            viniusepivos.Value = -14; // бухнуть на таком хп
            viniothodhp.Value = -14; // отойти по хп если стоит на ком то
            vinikordoff.Value = -14; // офнуть на таком хп
            vinihphealspell.Value = -14; // юзнуть книжку на таком хп
            vinihpforleftskill.Value = -14; // хп для левого скилла
            vinihpforrightskill.Value = -14; // хп для правого скилла

            // блок маны
            vinimana30.Value = -14; // начало стопа по мане
            vinimana50.Value = -14; // конец стопа по мане
            vinimana0.Value = -14; // бухнуть по мане
            viniminmanaspell.Value = -14; // минимум маны для атак спелла
            viniminmanaalhil.Value = -14; // минимум маны для хеал спелла
            viniminhpmobaspell.Value = -14; // минимум хп моба для атак спелла
            vinimanaforleftskill.Value = -14; // минимум маны для левого скилла
            vinimanaforrightskill.Value = -14; // минимум маны для правого скилла

            // блок пива
            viniusepivohponoff.Checked = false; // пьем ли вообще пиво
            vinikakoepiv.Text = ""; // название IMG с пивом
            vinipivopuhujkakoe.Checked = false; // пьем любое пиво
            viniusepivomanaonoff.Checked = false; // пьем ли вообще пиво
            vinikakoepivmana.Text = ""; // название IMG с пивом
            vinipivopuhujkakoemana.Checked = false; // пьем любое пиво

            // блок скиллов
            viniAtackSkillONOFF.Checked = false;
            viniDeffSkillONOFF.Checked = false;
            viniikonaAttackSkilla.Text = ""; // имг левого скилла
            viniikonadefskilla.Text = ""; // имг правого скилла
            viniuseleftskillpohp.Checked = false; // юзать левый скилл только если хп меньше vinihpforleftskill
            viniuserightskillpohp.Checked = false; // юзать правый скилл только если хп меньше vinihpforrightskill
            viniuseleftskillpomane.Checked = false; // юзатель левый скилл если мана ниже vinimanaforleftskill
            viniuserightskillpomane.Checked = false; // юзатель правый скилл если мана ниже vinimanaforleftskill
            vinionetimeskill.Checked = false; // юзать только 1 скилл за раз

            // нижний блок
            viniVremjaWaga.Value = 600; // скорость ходьбы
            vinivremenika.Text = "117"; //сколько минут кач, например 117 кач 243 отдых
            viniItmLuterVklju4en.Checked = false; // поднимать ли дроп
            viniZamenjatjPivoNaDrop.Checked = false; // заменять ли пиво на дроп
            viniperenosvinventidepot.Checked = false; // переидывать ли дроп в инвент/депот
            vinimanakontrolvklju4on.Checked = false; // регать ли ману
            vinivizovpeta.Checked = false; // вызывать ли пета
            vinihppet.Value = 10;
            class0.str = "";
            class0.oldgold = 0;
            class0.seanstime = 0;
            class0.oldexp = 0;
            class0.oldexptolvl = 0L;
            class0.oldlvl = 0;
            saveToolStripMenuItem.Enabled = false;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Saveini()
        {
            if (class0.str.Equals(""))
            {
                return;
            }
            //var fn = class0.str;
            // верний ряд
            class0.save = class0.save + "[time]" + Environment.NewLine;
            class0.save = class0.save + "; 1.1 дата оплаты" + Environment.NewLine;
            class0.save = class0.save + "oplatadate=" + oplatadate.Text + Environment.NewLine;
            class0.save = class0.save + "; 1.2 голды на начало стамы" + Environment.NewLine;
            class0.save = class0.save + "oldgold=" + class0.oldgold + Environment.NewLine;
            class0.save = class0.save + "; 1.3 время окончания текущей стамы" + Environment.NewLine;
            class0.save = class0.save + "seanstime=" + class0.seanstime + Environment.NewLine;
            class0.save = class0.save + "; 1.4 опыт на начало стамы" + Environment.NewLine;
            class0.save = class0.save + "oldexp=" + class0.oldexp + Environment.NewLine;
            class0.save = class0.save + "; 1.5 уровень на начало стамы" + Environment.NewLine;
            class0.save = class0.save + "oldlvl=" + class0.oldlvl + Environment.NewLine;
            class0.save = class0.save + "; 1.6 остаток опыта до апа на начало стамы" + Environment.NewLine;
            class0.save = class0.save + "oldexptolvl=" + class0.oldexptolvl + Environment.NewLine;
			class0.save += Environment.NewLine;

			class0.save = class0.save + "[pass]" + Environment.NewLine;
            class0.save = class0.save + "; 2.1 заходить или нет" + Environment.NewLine;
			var fa = (flag_auto.Checked == true) ? "1" : "0";
			class0.save = class0.save + "pass=" + fa + Environment.NewLine;
            class0.save = class0.save + "; 2.2 логин" + Environment.NewLine;
			class0.save = class0.save + "vinilogin=" + login.Text + Environment.NewLine;
            class0.save = class0.save + "; 2.3 пароль" + Environment.NewLine;
			class0.save = class0.save + "vinipass=" + pass.Text + Environment.NewLine;
            class0.save = class0.save + "; 2.4 мир" + Environment.NewLine;
			class0.save = class0.save + "viniworld=" + world.Text + Environment.NewLine;
            class0.save = class0.save + "; 2.5 номер стамины" + Environment.NewLine;
			class0.save = class0.save + "vininomerstamini=" + nomerstamini.Text + Environment.NewLine;
            class0.save = class0.save + "; 2.6 E-mail" + Environment.NewLine;
            class0.save = class0.save + "viniemail=" + email.Text + Environment.NewLine;
            class0.save = class0.save + "; 2.7 отправить логи на e-mail" + Environment.NewLine;
            fa = (emailonoff.Checked == true) ? "1" : "0";
            class0.save = class0.save + "viniemailonoff=" + fa + Environment.NewLine;
            class0.save += Environment.NewLine;

			class0.save = class0.save + "[nastrojki]" + Environment.NewLine;
            class0.save = class0.save + "; 3.1 маршрут (карта)" + Environment.NewLine;
			class0.save = class0.save + "viniPapkaSoSkriptom=" + viniPapkaSoSkriptom.Text + Environment.NewLine;
            class0.save = class0.save + "; 3.2 куда смотрим для поиска мобов" + Environment.NewLine;
            if (STORONAVZGLJADA.Text == "Вперед")
                fa = "0";
            else if (STORONAVZGLJADA.Text == "Назад")
                fa = "1";
            else
                fa = "2";
			class0.save = class0.save + "viniSTORONAVZGLJADA=" + fa + Environment.NewLine;
            class0.save = class0.save + "; 3.3 сколько секунд пауза если увидел моба" + Environment.NewLine;
			class0.save = class0.save + "viniuvidelwdet=" + uvidelwdet.Text + Environment.NewLine;
            class0.save = class0.save + "; 3.4 на сколько шагов сканировать мобов (2 или 3)" + Environment.NewLine;
            class0.save = class0.save + "viniobzorwagov=" + obzorwagov.Text + Environment.NewLine;
            class0.save += Environment.NewLine;

            // левый столбик
            class0.save = class0.save + "; 4.1 номер окна эмулятора" + Environment.NewLine;
			class0.save = class0.save + "vininomeroknatiba=" + nomeroknatiba.Text + Environment.NewLine;
            class0.save = class0.save + "; 4.2 координата X окна" + Environment.NewLine;
			class0.save = class0.save + "vinikoordinataX=" + koordinataX.Text + Environment.NewLine;
            class0.save = class0.save + "; 4.3 координата Y окна" + Environment.NewLine;
			class0.save = class0.save + "vinikoordinataY=" + koordinataY.Text + Environment.NewLine;
            class0.save = class0.save + "; 4.4 запускать следущего чара или тупо ждать после стамы" + Environment.NewLine;
            fa = (zapuskatjsleduwejskri.Checked == true) ? "1" : "0";
			class0.save = class0.save + "vinizapuskatjsleduwejskri=" + fa + Environment.NewLine;
            class0.save = class0.save + "; 4.5 название предыдущего скрипта" + Environment.NewLine;
			class0.save = class0.save + "vinistarijskript=" + starijskript.Text + Environment.NewLine;
            class0.save = class0.save + "; 4.6 название следующего скрипта" + Environment.NewLine;
			class0.save = class0.save + "vinisleduwijskript=" + sleduwijskript.Text + Environment.NewLine;
            class0.save = class0.save + "; 4.7 юзать книгу лечения" + Environment.NewLine;
            fa = (viniallhiljatsa.Checked == true) ? "1" : "0";
			class0.save = class0.save + "viniallhiljatsa=" + fa + Environment.NewLine;
            class0.save = class0.save + "; 4.8 юзать книгу атаки" + Environment.NewLine;
            fa = (viniavtomag.Checked == true) ? "1" : "0";
			class0.save = class0.save + "viniavtomag=" + fa + Environment.NewLine;
            class0.save = class0.save + "; 4.9 спелить ли на 3 шага" + Environment.NewLine;
            fa = (vinilongspell.Checked == true) ? "1" : "0";
            class0.save = class0.save + "vinilongspell=" + fa + Environment.NewLine;
            class0.save = class0.save + "; 4.10 эмулятор поверх остальных окон" + Environment.NewLine;
            fa = (vinialveistoponof.Checked == true) ? "on" : "off";
			class0.save = class0.save + "vinialveistoponof=" + fa + Environment.NewLine;
            class0.save = class0.save + "; 4.11 офать ли по стаме (54:00)" + Environment.NewLine;
            fa = (vininocheckstam.Checked == true) ? "1" : "0";
			class0.save = class0.save + "vininocheckstam=" + fa + Environment.NewLine;
            class0.save = class0.save + "; 4.12 использовать бафф" + Environment.NewLine;
            fa = (buffonoff.Checked == true) ? "1" : "0";
            class0.save = class0.save + "vinibuff=" + fa + Environment.NewLine;
            class0.save += Environment.NewLine;

            // блок здоровья
            int num;
            class0.save = class0.save + "; 5.1 начало стопа по хп" + Environment.NewLine;
            num = -1 * vini50php.Value;
			class0.save = class0.save + "vini50php=" + num + Environment.NewLine;
            class0.save = class0.save + "; 5.2 конец стопа по хп" + Environment.NewLine;
            num = -1 * vini100php.Value;
            class0.save = class0.save + "vini100php=" + num + Environment.NewLine;
            class0.save = class0.save + "; 5.3 пить пиво если хп меньше" + Environment.NewLine;
            num = -1 * viniusepivos.Value;
            class0.save = class0.save + "viniusepivos=" + num + Environment.NewLine;
            class0.save = class0.save + "; 5.4 хп, при которых чар офает на 2 минуты при трапе другим чаром" + Environment.NewLine;
            num = -1 * viniothodhp.Value;
            class0.save = class0.save + "viniothodhp=" + num + Environment.NewLine;
            class0.save = class0.save + "; 5.5 офнуть по хп" + Environment.NewLine;
            num = -1 * vinikordoff.Value;
            class0.save = class0.save + "vinikordoff=" + num + Environment.NewLine;
            class0.save = class0.save + "; 5.6 хп при которых пора юзать книгу лечения" + Environment.NewLine;
            num = -1 * vinihphealspell.Value;
            class0.save = class0.save + "vinihphealspell=" + num + Environment.NewLine;
            class0.save = class0.save + "; 5.7 хп для юзания левого скилла" + Environment.NewLine;
            num = -1 * vinihpforleftskill.Value;
            class0.save = class0.save + "vinihpforleftskill=" + num + Environment.NewLine;
            class0.save = class0.save + "; 5.8 хп для юзания правого скилла" + Environment.NewLine;
            num = -1 * vinihpforrightskill.Value;
            class0.save = class0.save + "vinihpforrightskill=" + num + Environment.NewLine;
			class0.save += Environment.NewLine;

            // блок маны
            class0.save = class0.save + "; 6.1 начало стопа по мане" + Environment.NewLine;
            num = -1 * vinimana30.Value;
            class0.save = class0.save + "vinimana30=" + num + Environment.NewLine;
            class0.save = class0.save + "; 6.2 конец стопа по мане" + Environment.NewLine;
            num = -1 * vinimana50.Value;
            class0.save = class0.save + "vinimana50=" + num + Environment.NewLine;
            class0.save = class0.save + "; 6.3 пить пиво если маны меньше этого значения" + Environment.NewLine;
            num = -1 * vinimana0.Value;
            class0.save = class0.save + "vinimana0=" + num + Environment.NewLine;
            class0.save = class0.save + "; 6.4 юзать книгу атаки если маны не менее этого значения" + Environment.NewLine;
            num = -1 * viniminmanaspell.Value;
            class0.save = class0.save + "viniminmanaspell=" + num + Environment.NewLine;
            class0.save = class0.save + "; 6.5 юзать книгу лечения если маны не менее этого значения" + Environment.NewLine;
            num = -1 * viniminmanaalhil.Value;
            class0.save = class0.save + "viniminmanaalhil=" + num + Environment.NewLine;
            class0.save = class0.save + "; 6.6 юзать книгу атаки если у моба хп не менее этого значения" + Environment.NewLine;
            num = -1 * viniminhpmobaspell.Value;
            class0.save = class0.save + "viniminhpmobaspell=" + num + Environment.NewLine;
            class0.save = class0.save + "; 6.7 мана для включения левого скилла" + Environment.NewLine;
            num = -1 * vinimanaforleftskill.Value;
            class0.save = class0.save + "vinimanaforleftskill=" + num + Environment.NewLine;
            class0.save = class0.save + "; 6.8 мана для включения правого скилла" + Environment.NewLine;
            num = -1 * vinimanaforrightskill.Value;
            class0.save = class0.save + "vinimanaforrightskill=" + num + Environment.NewLine;
			class0.save += Environment.NewLine;

            // блок пива
            class0.save = class0.save + "; 7.1 пить ли пиво по хп" + Environment.NewLine;
            fa = (viniusepivohponoff.Checked == true) ? "1" : "0";
			class0.save = class0.save + "viniusepivohponoff=" + fa + Environment.NewLine;
            class0.save = class0.save + "; 7.2 какое именно пить пиво по хп" + Environment.NewLine;
			class0.save = class0.save + "vinikakoepiv=" + vinikakoepiv.Text + Environment.NewLine;
            class0.save = class0.save + "; 7.3 флаг что пить любое пиво по хп" + Environment.NewLine;
            fa = (vinipivopuhujkakoe.Checked == true) ? "1" : "0";
			class0.save = class0.save + "vinipivopuhujkakoe=" + fa + Environment.NewLine;
            class0.save = class0.save + "; 7.4 пить ли пиво по мане" + Environment.NewLine;
            fa = (viniusepivomanaonoff.Checked == true) ? "1" : "0";
            class0.save = class0.save + "viniusepivomanaonoff=" + fa + Environment.NewLine;
            class0.save = class0.save + "; 7.5 какое пить пиво по мане" + Environment.NewLine;
            class0.save = class0.save + "vinikakoepivmana=" + vinikakoepivmana.Text + Environment.NewLine;
            class0.save = class0.save + "; 7.6 флаг что пить любое пиво по мане" + Environment.NewLine;
            fa = (vinipivopuhujkakoemana.Checked == true) ? "1" : "0";
            class0.save = class0.save + "vinipivopuhujkakoemana=" + fa + Environment.NewLine;
            class0.save += Environment.NewLine;

            // блок скиллов
            class0.save = class0.save + "; 8.1 юзать ли левый скилл" + Environment.NewLine;
            fa = (viniAtackSkillONOFF.Checked == true) ? "1" : "0";
			class0.save = class0.save + "viniAtackSkillONOFF=" + fa + Environment.NewLine;
            class0.save = class0.save + "; 8.2 юзать ли правый скилл" + Environment.NewLine;
            fa = (viniDeffSkillONOFF.Checked == true) ? "1" : "0";
			class0.save = class0.save + "viniDeffSkillONOFF=" + fa + Environment.NewLine;
            class0.save = class0.save + "; 8.3 какой именно левый скилл" + Environment.NewLine;
			class0.save = class0.save + "viniikonaAttackSkilla=" + viniikonaAttackSkilla.Text + Environment.NewLine;
            class0.save = class0.save + "; 8.4 какой именно правый скилл" + Environment.NewLine;
			class0.save = class0.save + "viniikonadefskilla=" + viniikonadefskilla.Text + Environment.NewLine;
            class0.save = class0.save + "; 8.5 юзать левый скилл если хп менее 5.7" + Environment.NewLine;
            fa = (viniuseleftskillpohp.Checked == true) ? "1" : "0";
            class0.save = class0.save + "viniuseleftskillpohp=" + fa + Environment.NewLine;
            class0.save = class0.save + "; 8.6 юзать правый скилл если хп менее 5.8" + Environment.NewLine;
            fa = (viniuserightskillpohp.Checked == true) ? "1" : "0";
            class0.save = class0.save + "viniuserightskillpohp=" + fa + Environment.NewLine;
            class0.save = class0.save + "; 8.7 юзать левый скилл если мана менее 6.7" + Environment.NewLine;
            fa = (viniuseleftskillpomane.Checked == true) ? "1" : "0";
            class0.save = class0.save + "viniuseleftskillpomane=" + fa + Environment.NewLine;
            class0.save = class0.save + "; 8.8 юзать правый скилл если мана менее 6.8" + Environment.NewLine;
            fa = (viniuserightskillpomane.Checked == true) ? "1" : "0";
            class0.save = class0.save + "viniuserightskillpomane=" + fa + Environment.NewLine;
            class0.save = class0.save + "; 8.9 юзать только 1 скилл за раз" + Environment.NewLine;
            fa = (vinionetimeskill.Checked == true) ? "1" : "0";
            class0.save = class0.save + "vinionetimeskill=" + fa + Environment.NewLine;
			class0.save += Environment.NewLine;

            // нижний блок
            class0.save = class0.save + "; 9.1 задержка между шагами (милисекунды)" + Environment.NewLine;
			class0.save = class0.save + "viniVremjaWaga=" + viniVremjaWaga.Value + Environment.NewLine;
            class0.save = class0.save + "; 9.2 время кача в минутах" + Environment.NewLine;
			class0.save = class0.save + "vinivremenika=" + vinivremenika.Text + Environment.NewLine;
            class0.save = class0.save + "; 9.3 поднимать ли лут" + Environment.NewLine;
            fa = (viniItmLuterVklju4en.Checked == true) ? "1" : "0";
            class0.save = class0.save + "viniItmLuterVklju4en=" + fa + Environment.NewLine;
            class0.save = class0.save + "; 9.4 заменять ли пиво на лут" + Environment.NewLine;
            fa = (viniZamenjatjPivoNaDrop.Checked == true) ? "1" : "0";
            class0.save = class0.save + "viniZamenjatjPivoNaDrop=" + fa + Environment.NewLine;
            class0.save = class0.save + "; 9.5 перекидывать ли лут в инвент и депот" + Environment.NewLine;
            fa = (viniperenosvinventidepot.Checked == true) ? "1" : "0";
            class0.save = class0.save + "viniperenosvinventidepot=" + fa + Environment.NewLine;
            class0.save = class0.save + "; 9.6 регать ли ману" + Environment.NewLine;
            fa = (vinimanakontrolvklju4on.Checked == true) ? "1" : "0";
            class0.save = class0.save + "vinimanakontrolvklju4on=" + fa + Environment.NewLine;
            class0.save = class0.save + "; 9.7 питомец" + Environment.NewLine;
            fa = (vinivizovpeta.Checked == true) ? "1" : "0";
            class0.save = class0.save + "vinivizovpeta=" + fa + Environment.NewLine;
            class0.save = class0.save + "; 9.8 хп пета для оффа" + Environment.NewLine;
            class0.save = class0.save + "vinihppet=" + vinihppet.Value + Environment.NewLine;
			class0.save += Environment.NewLine;
			System.IO.File.WriteAllText(@class0.str, class0.save, Encoding.GetEncoding(1251));
            class0.save = "";
            MessageBox.Show("Успешно сохранено!");
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Saveini();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            class0.str = saveFileDialog1.FileName;
            saveToolStripMenuItem.Enabled = true;
            Saveini();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout fabout = new FormAbout();
            fabout.ShowDialog();
        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInfo finfo = new FormInfo();
            finfo.ShowDialog();
        }

        private void Nomeroknatiba_TextChanged(object sender, EventArgs e)
        {
            var numm = Int32.Parse(nomeroknatiba.Text);
            var stamm = Int32.Parse(nomerstamini.Text);
            var next = stamm + 1;
            if (next > 3)
            {
                next = 1;
            }
            var past = stamm - 1;
            if (past < 1)
            {
                past = 3;
            }
            var strnext = numm + "." + next + ".exe";
            var strpast = numm + "." + past + ".exe";
            starijskript.Text = strpast;
            sleduwijskript.Text = strnext;
        }

        private void WarHighLvlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viniallhiljatsa.Checked = false; // вкл/выкл хеал спелл
            viniavtomag.Checked = true; // вкл/выкл атак спелл
            vinilongspell.Checked = false; // вкл/выкл спелл на 3 шага

            // блок здоровья
            vini50php.Value = -54; // начало стопа по хп
            vini100php.Value = -14; // конец стопа по хп
            viniusepivos.Value = -67; // бухнуть на таком хп
            viniothodhp.Value = -29; // отойти по хп если стоит на ком то
            vinikordoff.Value = -75; // офнуть на таком хп
            vinihphealspell.Value = -65; // юзнуть книжку на таком хп
            vinihpforleftskill.Value = -14; // хп для левого скилла
            vinihpforrightskill.Value = -14; // хп для правого скилла

            // блок маны
            vinimana30.Value = -71; // начало стопа по мане
            vinimana50.Value = -14; // конец стопа по мане
            vinimana0.Value = -78; // бухнуть по мане
            viniminmanaspell.Value = -70; // минимум маны для атак спелла
            viniminmanaalhil.Value = -70; // минимум маны для хеал спелла
            viniminhpmobaspell.Value = -67; // минимум хп моба для атак спелла
            vinimanaforleftskill.Value = -14; // минимум маны для левого скилла
            vinimanaforrightskill.Value = -14; // минимум маны для правого скилла

            // блок пива
            viniusepivohponoff.Checked = true; // пьем ли вообще пиво
            vinikakoepiv.Text = "Minor_Health_Potion"; // название IMG с пивом
            vinipivopuhujkakoe.Checked = true; // пьем любое пиво
            viniusepivomanaonoff.Checked = false; // пьем ли вообще пиво
            vinikakoepivmana.Text = "Minor_Mana_Potion"; // название IMG с пивом
            vinipivopuhujkakoemana.Checked = false; // пьем любое пиво

            // блок скиллов
            viniAtackSkillONOFF.Checked = true;
            viniDeffSkillONOFF.Checked = true;
            viniikonaAttackSkilla.Text = "Double_Attack"; // имг левого скилла
            viniikonadefskilla.Text = "Battlemaster"; // имг правого скилла
            viniuseleftskillpohp.Checked = false; // юзать левый скилл только если хп меньше vinihpforleftskill
            viniuserightskillpohp.Checked = false; // юзать правый скилл только если хп меньше vinihpforrightskill
            viniuseleftskillpomane.Checked = false; // юзатель левый скилл если мана ниже vinimanaforleftskill
            viniuserightskillpomane.Checked = false; // юзатель правый скилл если мана ниже vinimanaforleftskill
        }

        private void WarLowLvlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viniallhiljatsa.Checked = true; // вкл/выкл хеал спелл
            viniavtomag.Checked = true; // вкл/выкл атак спелл
            vinilongspell.Checked = false; // вкл/выкл спелл на 3 шага

            // блок здоровья
            vini50php.Value = -37; // начало стопа по хп
            vini100php.Value = -14; // конец стопа по хп
            viniusepivos.Value = -56; // бухнуть на таком хп
            viniothodhp.Value = -29; // отойти по хп если стоит на ком то
            vinikordoff.Value = -75; // офнуть на таком хп
            vinihphealspell.Value = -47; // юзнуть книжку на таком хп
            vinihpforleftskill.Value = -14; // хп для левого скилла
            vinihpforrightskill.Value = -14; // хп для правого скилла

            // блок маны
            vinimana30.Value = -53; // начало стопа по мане
            vinimana50.Value = -14; // конец стопа по мане
            vinimana0.Value = -68; // бухнуть по мане
            viniminmanaspell.Value = -50; // минимум маны для атак спелла
            viniminmanaalhil.Value = -50; // минимум маны для хеал спелла
            viniminhpmobaspell.Value = -64; // минимум хп моба для атак спелла
            vinimanaforleftskill.Value = -14; // минимум маны для левого скилла
            vinimanaforrightskill.Value = -14; // минимум маны для правого скилла

            // блок пива
            viniusepivohponoff.Checked = true; // пьем ли вообще пиво
            vinikakoepiv.Text = "Minor_Health_Potion"; // название IMG с пивом
            vinipivopuhujkakoe.Checked = true; // пьем любое пиво
            viniusepivomanaonoff.Checked = false; // пьем ли вообще пиво
            vinikakoepivmana.Text = "Minor_Mana_Potion"; // название IMG с пивом
            vinipivopuhujkakoemana.Checked = false; // пьем любое пиво

            // блок скиллов
            viniAtackSkillONOFF.Checked = true;
            viniDeffSkillONOFF.Checked = true;
            viniikonaAttackSkilla.Text = "Expertise"; // имг левого скилла
            viniikonadefskilla.Text = "Hardskin"; // имг правого скилла
            viniuseleftskillpohp.Checked = false; // юзать левый скилл только если хп меньше vinihpforleftskill
            viniuserightskillpohp.Checked = false; // юзать правый скилл только если хп меньше vinihpforrightskill
            viniuseleftskillpomane.Checked = false; // юзатель левый скилл если мана ниже vinimanaforleftskill
            viniuserightskillpomane.Checked = false; // юзатель правый скилл если мана ниже vinimanaforleftskill
        }

        private void WizHighLvlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viniallhiljatsa.Checked = false; // вкл/выкл хеал спелл
            viniavtomag.Checked = true; // вкл/выкл атак спелл
            vinilongspell.Checked = true; // вкл/выкл спелл на 3 шага
            vinimanakontrolvklju4on.Checked = true; // регать ману

            // блок здоровья
            vini50php.Value = -54; // начало стопа по хп
            vini100php.Value = -14; // конец стопа по хп
            viniusepivos.Value = -67; // бухнуть на таком хп
            viniothodhp.Value = -29; // отойти по хп если стоит на ком то
            vinikordoff.Value = -75; // офнуть на таком хп
            vinihphealspell.Value = -65; // юзнуть книжку на таком хп
            vinihpforleftskill.Value = -14; // хп для левого скилла
            vinihpforrightskill.Value = -38; // хп для правого скилла

            // блок маны
            vinimana30.Value = -61; // начало стопа по мане
            vinimana50.Value = -14; // конец стопа по мане
            vinimana0.Value = -78; // бухнуть по мане
            viniminmanaspell.Value = -64; // минимум маны для атак спелла
            viniminmanaalhil.Value = -64; // минимум маны для хеал спелла
            viniminhpmobaspell.Value = -67; // минимум хп моба для атак спелла
            vinimanaforleftskill.Value = -46; // минимум маны для левого скилла
            vinimanaforrightskill.Value = -26; // минимум маны для правого скилла

            // блок пива
            viniusepivohponoff.Checked = true; // пьем ли вообще пиво
            vinikakoepiv.Text = "Minor_Health_Potion"; // название IMG с пивом
            vinipivopuhujkakoe.Checked = true; // пьем любое пиво
            viniusepivomanaonoff.Checked = false; // пьем ли вообще пиво
            vinikakoepivmana.Text = "Minor_Mana_Potion"; // название IMG с пивом
            vinipivopuhujkakoemana.Checked = false; // пьем любое пиво

            // блок скиллов
            viniAtackSkillONOFF.Checked = true;
            viniDeffSkillONOFF.Checked = true;
            viniikonaAttackSkilla.Text = "Rupture_Attack"; // имг левого скилла
            viniikonadefskilla.Text = "Renew"; // имг правого скилла
            viniuseleftskillpohp.Checked = false; // юзать левый скилл только если хп меньше vinihpforleftskill
            viniuserightskillpohp.Checked = true; // юзать правый скилл только если хп меньше vinihpforrightskill
            viniuseleftskillpomane.Checked = false; // юзатель левый скилл если мана ниже vinimanaforleftskill
            viniuserightskillpomane.Checked = true; // юзатель правый скилл если мана ниже vinimanaforleftskill
        }

        private void WizLowLvlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viniallhiljatsa.Checked = true; // вкл/выкл хеал спелл
            viniavtomag.Checked = true; // вкл/выкл атак спелл
            vinilongspell.Checked = true; // вкл/выкл спелл на 3 шага
            vinimanakontrolvklju4on.Checked = true; // регать ману

            // блок здоровья
            vini50php.Value = -43; // начало стопа по хп
            vini100php.Value = -14; // конец стопа по хп
            viniusepivos.Value = -61; // бухнуть на таком хп
            viniothodhp.Value = -29; // отойти по хп если стоит на ком то
            vinikordoff.Value = -75; // офнуть на таком хп
            vinihphealspell.Value = -65; // юзнуть книжку на таком хп
            vinihpforleftskill.Value = -14; // хп для левого скилла
            vinihpforrightskill.Value = -50; // хп для правого скилла

            // блок маны
            vinimana30.Value = -68; // начало стопа по мане
            vinimana50.Value = -14; // конец стопа по мане
            vinimana0.Value = -78; // бухнуть по мане
            viniminmanaspell.Value = -64; // минимум маны для атак спелла
            viniminmanaalhil.Value = -64; // минимум маны для хеал спелла
            viniminhpmobaspell.Value = -67; // минимум хп моба для атак спелла
            vinimanaforleftskill.Value = -30; // минимум маны для левого скилла
            vinimanaforrightskill.Value = -40; // минимум маны для правого скилла

            // блок пива
            viniusepivohponoff.Checked = true; // пьем ли вообще пиво
            vinikakoepiv.Text = "Minor_Health_Potion"; // название IMG с пивом
            vinipivopuhujkakoe.Checked = true; // пьем любое пиво
            viniusepivomanaonoff.Checked = true; // пьем ли вообще пиво
            vinikakoepivmana.Text = "Minor_Mana_Potion"; // название IMG с пивом
            vinipivopuhujkakoemana.Checked = true; // пьем любое пиво

            // блок скиллов
            viniAtackSkillONOFF.Checked = true;
            viniDeffSkillONOFF.Checked = true;
            viniikonaAttackSkilla.Text = "Mana_Leech"; // имг левого скилла
            viniikonadefskilla.Text = "Meditation"; // имг правого скилла
            viniuseleftskillpohp.Checked = false; // юзать левый скилл только если хп меньше vinihpforleftskill
            viniuserightskillpohp.Checked = true; // юзать правый скилл только если хп меньше vinihpforrightskill
            viniuseleftskillpomane.Checked = true; // юзатель левый скилл если мана ниже vinimanaforleftskill
            viniuserightskillpomane.Checked = true; // юзатель правый скилл если мана ниже vinimanaforleftskill
        }

        private void WizMiddleLvlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viniallhiljatsa.Checked = true; // вкл/выкл хеал спелл
            viniavtomag.Checked = true; // вкл/выкл атак спелл
            vinilongspell.Checked = true; // вкл/выкл спелл на 3 шага
            vinimanakontrolvklju4on.Checked = true; // регать ману

            // блок здоровья
            vini50php.Value = -43; // начало стопа по хп
            vini100php.Value = -14; // конец стопа по хп
            viniusepivos.Value = -61; // бухнуть на таком хп
            viniothodhp.Value = -29; // отойти по хп если стоит на ком то
            vinikordoff.Value = -75; // офнуть на таком хп
            vinihphealspell.Value = -65; // юзнуть книжку на таком хп
            vinihpforleftskill.Value = -14; // хп для левого скилла
            vinihpforrightskill.Value = -50; // хп для правого скилла

            // блок маны
            vinimana30.Value = -68; // начало стопа по мане
            vinimana50.Value = -14; // конец стопа по мане
            vinimana0.Value = -78; // бухнуть по мане
            viniminmanaspell.Value = -64; // минимум маны для атак спелла
            viniminmanaalhil.Value = -64; // минимум маны для хеал спелла
            viniminhpmobaspell.Value = -67; // минимум хп моба для атак спелла
            vinimanaforleftskill.Value = -30; // минимум маны для левого скилла
            vinimanaforrightskill.Value = -40; // минимум маны для правого скилла

            // блок пива
            viniusepivohponoff.Checked = true; // пьем ли вообще пиво
            vinikakoepiv.Text = "Minor_Health_Potion"; // название IMG с пивом
            vinipivopuhujkakoe.Checked = true; // пьем любое пиво
            viniusepivomanaonoff.Checked = true; // пьем ли вообще пиво
            vinikakoepivmana.Text = "Minor_Mana_Potion"; // название IMG с пивом
            vinipivopuhujkakoemana.Checked = true; // пьем любое пиво

            // блок скиллов
            viniAtackSkillONOFF.Checked = true;
            viniDeffSkillONOFF.Checked = true;
            viniikonaAttackSkilla.Text = "Mana_Leech"; // имг левого скилла
            viniikonadefskilla.Text = "Renew"; // имг правого скилла
            viniuseleftskillpohp.Checked = false; // юзать левый скилл только если хп меньше vinihpforleftskill
            viniuserightskillpohp.Checked = true; // юзать правый скилл только если хп меньше vinihpforrightskill
            viniuseleftskillpomane.Checked = true; // юзатель левый скилл если мана ниже vinimanaforleftskill
            viniuserightskillpomane.Checked = true; // юзатель правый скилл если мана ниже vinimanaforleftskill
        }

        private void WarMiddleLvlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viniallhiljatsa.Checked = true; // вкл/выкл хеал спелл
            viniavtomag.Checked = true; // вкл/выкл атак спелл
            vinilongspell.Checked = false; // вкл/выкл спелл на 3 шага

            // блок здоровья
            vini50php.Value = -37; // начало стопа по хп
            vini100php.Value = -14; // конец стопа по хп
            viniusepivos.Value = -56; // бухнуть на таком хп
            viniothodhp.Value = -29; // отойти по хп если стоит на ком то
            vinikordoff.Value = -75; // офнуть на таком хп
            vinihphealspell.Value = -47; // юзнуть книжку на таком хп
            vinihpforleftskill.Value = -14; // хп для левого скилла
            vinihpforrightskill.Value = -14; // хп для правого скилла

            // блок маны
            vinimana30.Value = -53; // начало стопа по мане
            vinimana50.Value = -14; // конец стопа по мане
            vinimana0.Value = -68; // бухнуть по мане
            viniminmanaspell.Value = -50; // минимум маны для атак спелла
            viniminmanaalhil.Value = -50; // минимум маны для хеал спелла
            viniminhpmobaspell.Value = -64; // минимум хп моба для атак спелла
            vinimanaforleftskill.Value = -14; // минимум маны для левого скилла
            vinimanaforrightskill.Value = -14; // минимум маны для правого скилла

            // блок пива
            viniusepivohponoff.Checked = true; // пьем ли вообще пиво
            vinikakoepiv.Text = "Minor_Health_Potion"; // название IMG с пивом
            vinipivopuhujkakoe.Checked = true; // пьем любое пиво
            viniusepivomanaonoff.Checked = false; // пьем ли вообще пиво
            vinikakoepivmana.Text = "Minor_Mana_Potion"; // название IMG с пивом
            vinipivopuhujkakoemana.Checked = false; // пьем любое пиво

            // блок скиллов
            viniAtackSkillONOFF.Checked = true;
            viniDeffSkillONOFF.Checked = true;
            viniikonaAttackSkilla.Text = "Double_Attack"; // имг левого скилла
            viniikonadefskilla.Text = "Warden_Armour"; // имг правого скилла
            viniuseleftskillpohp.Checked = false; // юзать левый скилл только если хп меньше vinihpforleftskill
            viniuserightskillpohp.Checked = false; // юзать правый скилл только если хп меньше vinihpforrightskill
            viniuseleftskillpomane.Checked = false; // юзатель левый скилл если мана ниже vinimanaforleftskill
            viniuserightskillpomane.Checked = false; // юзатель правый скилл если мана ниже vinimanaforleftskill
        }
    }
    public class Class0
    {
        public String str = "";
        public String save = "";
        public long oldgold = 0;
        public long seanstime = 0;
        public long oldexp = 0;
        public long oldexptolvl = 0;
        public long oldlvl = 0;
    }
}
