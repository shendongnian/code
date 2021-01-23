    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Visible = false;
            new Form2().Show();
        }
    
        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = DateTime.Now.ToString();
        }
    }
