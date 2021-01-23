    public partial class Service1 : ServiceBase
    {
        //Need to keep a reference to this object, else the Garbage Collector will clean it up and prevent further events from firing.
        private System.Threading.Timer _timer;
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                var service = new Service1();
                Log.Debug("Starting Console Application");
                service.OnStart(args);
                // The service can now be accessed.
                Console.WriteLine("Service ready.");
                Console.WriteLine("Press <ENTER> to terminate the application.");
                Console.ReadLine();
                service.OnStop();
                return;
            }
            var servicesToRun = new ServiceBase[] 
                                              { 
                                                  new Service1() 
                                              };
            Run(servicesToRun);
        }
        public Service1()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            // For a single instance, this is a bit heavy handed, but if you're creating of a number of them
            // the NT service will need to return in a short period of time and thus I use QueueUserWorkItem
            ThreadPool.QueueUserWorkItem(SetupTimer, args);
        }
        protected override void OnStop()
        {
        }
        private void SetupTimer(object obj)
        {
            //Set the emailInterval to be 1 minute by default
            const int interval = 1;
            //Initialize the timer, wait 5 seconds before firing, and then fire every 15 minutes
            _timer = new Timer(TimerDelegate, 5000, 1, 1000 * 60 * interval);
        }
        private static void TimerDelegate(object stateInfo)
        {
                //Perform your DB TTL Check here
        }
    }
