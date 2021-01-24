    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GlobalVariables G = new GlobalVariables();
            string[] array = new string[3];
            array[0] = textBox1.Text;
            array[1] = textBox2.Text;
            array[2] = textBox3.Text;
            G.Array = array;
            Form2 f2 = new Form2(array);
            f2.Show();
        }        
    }
