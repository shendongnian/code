    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            userControl11.HandleKeys(keyData); // method on the userControl to handle the key code.
            base.ProcessCmdKey(ref msg, keyData);
            return true;
        }
    }
