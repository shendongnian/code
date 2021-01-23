    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Framerate = "Test1";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(this);
            frm.Show();
        }
        private void test()
        {
            label2.Text = Framerate;
        }
        public string Framerate
        {
            get { return label1.Text; }
            set
            {
                label1.Text = value;
                test();
            }
        }
    }
