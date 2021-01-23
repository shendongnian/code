     public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }
        internal void TestMethod()
        {
            throw new NotImplementedException();
        }
    }
    public partial class Form2 : Form
    {
        private Form1 form1;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form1 form1)
            : this()
        {
            // TODO: Complete member initialization
            this.form1 = form1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            form1.TestMethod();
        }
    }
