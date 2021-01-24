    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; // Clancel closing
            Visible = false; // Instead, make Form2 invisible.
        }
    }
