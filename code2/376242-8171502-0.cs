    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate("http://www.google.com");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Some Text");
        }
    }
