    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("C:\\blank.htm");
            Application.DoEvents();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.InvokeScript("InitEditor");
        }
    }
