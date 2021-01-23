    public partial class Service1 : ServiceBase
    {
        private Timer timer;
        
        public Service1()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            timer = new Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            using (StreamWriter writer = File.AppendText(@"C:\Users\alfonso\Desktop\log.txt"))
            {
                writer.WriteLine(string.Format("{0} : {1}", DateTime.Now, "Logging from the service"));
            }
        }
        protected override void OnStop()
        {
        }
    }
