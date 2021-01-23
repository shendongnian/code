    namespace WindowsFormsApplication1
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        Thread ControlThread;
        Thread BuildThread1;
        Thread BuildThread2;
        volatile bool RunBuilders = true;
        volatile bool RunControl = true;
        private void button1_Click(object sender, EventArgs e)
        {
            ControlThread = new Thread(new ThreadStart(Run));
            ControlThread.Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            RunControl = false;
            if (ControlThread != null)
            {
                while (ControlThread.IsAlive)
                {
                    Thread.Sleep(100);
                }
                //somehow Join did not work
                ControlThread.Join();
            }
        }
        public void Run()
        {   //Known as Child1
            //code to setup coms is here
            //Launch Builder threads
            RunBuilders = true;
            //Known as Child2 and Child3
            BuildThread1 = new Thread(new ThreadStart(Cam1Builder));
            BuildThread2 = new Thread(new ThreadStart(Cam1Builder));
            BuildThread1.Start();
            BuildThread2.Start();
            while (RunControl)
            {
            //// Code that waits for coms and tosses data into lists
            }
            RunBuilders = false;
            //Wait for threads to terminate
            BuildThread1.Join();
            BuildThread2.Join();
        }
        public void Cam1Builder()
        {
            while ( RunBuilders )
            {
            }
        }
    }
    }
