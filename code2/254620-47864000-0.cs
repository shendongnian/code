    public partial class Form1 : Form
    {
        DateTime date = new DateTime();
        public Form1()
        {
            InitializeComponent();
    }
        private void timer1_Tick(object sender, EventArgs e)
        {
            date = DateTime.Now;
            this.Text = "Date: "+date;
        }
    }
