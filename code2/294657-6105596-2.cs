    public class MyForm1 : Form
    {
        public MyForm1()
        {
            InitializeComponent();
        }
        public void SetImage(Image image)
        {
            pictureBox1.Image = image;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var form2 = new Form2(this);
            form2.Show();
        }
    }
    public class MyForm2 : Form
    {
        private MyForm1 form1;
        public MyForm2()
        {
            InitializeComponent();
        }
        public MyForm2(MyForm1 form1)
        {
            this.form1 = form1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            form1.SetImage(yourImage);
        }
    }
