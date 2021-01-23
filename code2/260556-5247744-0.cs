    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int d;
            for (d = 0; d <= 100; d++)
                progressBar1.Value = d;
            this.Hide();
            Form1().Show();
            timer1.Enabled = false;
        }
        
       
        
    }
}
