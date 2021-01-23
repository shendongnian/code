    public partial class frmSplashScreen : Form
    {
        public frmSplashScreen()
        {
            InitializeComponent();
        }
        public int LeftTime { get; set; }
        private void frmSplashScreen_Load(object sender, EventArgs e)
        {
            LeftTime = 20;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (LeftTime > 0)
            {
                LeftTime--;
            }
            else
            {
                timer1.Stop();
                new frmHomeScreen().Show();
                this.Hide();
            }
        }
    }
