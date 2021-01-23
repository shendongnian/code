       public partial class Service1 : ServiceBase
    {
        ServiceHost host;
        Thread hostThread;
        public Service1()
        {
            InitializeComponent();
             hostThread= new Thread(new ThreadStart(StartHosting));
        }
        protected override void OnStart(string[] args)
        {
            hostThread.Start();
        }
        protected void StartHosting()
        {
            host = new ServiceHost(typeof(WCFAuth.Service.AuthService));
            host.Open();
        }
        protected override void OnStop()
        {
            if (host != null)
                host.Close();
        }
    }
