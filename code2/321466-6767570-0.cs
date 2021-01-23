     partial class Service1 : ServiceBase
     {
        private Program program;
        
        public Service1()
        {
            InitializeComponent();
            program = new Program ();
        }
    
        protected override void OnStart(string[] args)
        {
            program.Start ();
        }
    
        protected override void OnStop()
        {
            program.Stop ();
        }
    }
    
    class Program
    {
        private Systems.Timers.Timer timer;
        
        public Program ()
        {
            timer = new System.Timers.Timer ();
            timer.Interval = 10000;
            timer.Elapsed += new ElapsedEventHandler (timer_Elapsed);
            
        }
    
        public void Start () 
        {
            timer.Enabled = true;
        }
        
        public void Stop ()
        {
            timer.Enabled = false;
        }
    
        public static void timer_Elapsed (object sender, EventArgs e)
        {
            EventLog.WriteEntry ("ProcessThread1", "Process1 Works");
        }
    }
