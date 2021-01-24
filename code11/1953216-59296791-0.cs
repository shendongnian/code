    public partial class Form1 : Form
    {
        private System.Timers.Timer myTimer;
        public Form1()
        {
            InitializeComponent();
            myTimer = new System.Timers.Timer(100);
            myTimer.Elapsed += new System.Timers.ElapsedEventHandler(myTimer_Elapsed);
            myTimer.AutoReset = true;
            myTimer.SynchronizingObject = this;
        }
        private void myTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            pictureBox1.Location = new Point(pictureBox1.Location.X + 1, pictureBox1.Location.Y);
        }
        private void btStart_Click(object sender, EventArgs e)
        {
            myTimer.Enabled = true;
        }
    }
