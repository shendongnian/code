    namespace WindowsFormsApp1
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            Form2 hi = new Form2();
            hi.Show();
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2.label2.Text = "Mathman";
        }
    }
    }
