    public partial class Form1 : Form
    {
        private HanteraKund hanteraKund;
        private Controller controller;
        public Form1()
        {
            hanteraKund = new HanteraKund();
            controller = new Controller(hanteraKund);
        }
    }
