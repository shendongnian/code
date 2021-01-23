    public partial class Form1 : Form
    {
        private MyDialog theDialog;
        public Form1()
        {
            InitializeComponent();
            theDialog = new MyDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            theDialog.ShowDialog();
        }
    }
