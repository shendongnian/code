    public partial class Form1 : Form
    {
        private Form2 _frm2 = new Form2();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _frm2.textBox1.Text = "Hello";
            _frm2.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            _frm2.Show();
        }
    }
