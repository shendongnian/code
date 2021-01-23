    public partial class Form2 : Form
    {
        public Form2(int id)
        {
            InitializeComponent();
            label1.Text = id.ToString();
        }
        public void moto()
        {
            textBox1.Text = "MAHESH";
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        Form2 f2 = new Form2(101);
        f2.moto();
        f2.ShowDialog();
    }
