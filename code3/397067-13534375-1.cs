    public partial class TestFrom : Form
    {
        private Thread threadP;
        private System.Windows.Forms.Timer Timer = new System.Windows.Forms.Timer();
        private string str;
        public TestFrom()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Timer.Interval =100;
            Timer.Tick += new EventHandler(TimeBussiness);
            Timer.Enabled = true;
            Timer.Start();
            Timer.Tag = "Start";
        }
        void TimeBussiness(object sender, EventArgs e)
        {
            if (threadP.ThreadState == ThreadState.Running)
            {
                Timer.Stop();
                Timer.Tag = "Stop";
            }
            else
            {
                //do my bussiness1;
            }
         }
        private void button3_Click(object sender, EventArgs e)
        {
            ThreadStart threadStart = new ThreadStart(Salver);
            threadP= new Thread(threadStart);
            threadP.Start();
        }
        private void Salver()
        {
            while (Timer.Tag == "Stop")
            {
            }
            //do my bussiness2;
            Timer.Start();
            Timer.Tag = "Start";
        }
    }
