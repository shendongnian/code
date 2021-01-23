    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void moto()
        {
            textBox1.Text = "MAHESH";
        }
        public int Id
        {
           set {label1.Text = value.ToString();}
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        Form2 f2 = new Form2();
        f2.Id = 101;
        f2.moto();
        f2.ShowDialog();
    }
