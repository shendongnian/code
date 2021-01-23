    public partial class Form1 : Form
    {
        private MyDialog theDialog;
        public Form1()
        {
            InitializeComponent();
            theDialog = new MyDialog();
            theDialog.FormClosing += new FormClosingEventHandler(theDialog_FormClosing);
        }
        void theDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            theDialog.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (theDialog.Visible)
            {
                theDialog.BringToFront();
            }
            else
            {
                theDialog.ShowDialog();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (theDialog.Visible)
            {
                theDialog.BringToFront();
            }
            else
            {
                theDialog.Show();
            }
        }
    }
