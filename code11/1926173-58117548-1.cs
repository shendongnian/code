    public partial class Form1 : Form
    {
        string name = "test";
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            name = "John Doe";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(name);
        }
    }
