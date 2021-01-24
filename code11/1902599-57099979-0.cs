    //UserControl1
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var a = Parent as FlowLayoutPanel;
            Form f = a.FindForm();
            Control[] s = f.Controls.Find("richTextBox1", true);
            s[0].Text = "hello";
        }
    }
    //Form1
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            UserControl1 uc = new UserControl1();
            flowLayoutPanel1.Controls.Add(uc);
        }
    }
