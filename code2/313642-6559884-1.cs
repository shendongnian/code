    [ServiceContract]
    public interface ISingletonProgram
    {
        [OperationContract]
        void CallWithArguments(string[] args);
    }
    class SingletonProgram : ISingletonProgram
    {
        public void CallWithArguments(string[] args)
        {
            // handle the arguments somehow
        }
    }
    public partial class App : Application
    {
        private readonly Mutex m_mutex;
        private ServiceHost m_serviceHost;
        private static string EndpointUri =
            "net.pipe://localhost/RuzovyJeliman/singletonProgram";
        public App()
        {
            // find out whether other instance exists
            bool createdNew;
            m_mutex = new Mutex(true, "RůžovýJeliman", out createdNew);
            if (!createdNew)
            {
                // other instance exists, call it and exit
                CallService();
                Shutdown();
                return;
            }
            // other instance does not exist
            // start the service to accept calls and show UI
            StartService();
            // show the main window here
            // you can also process this instance's command line arguments
        }
        private static void CallService()
        {
            var factory = new ChannelFactory<ISingletonProgram>(
                new NetNamedPipeBinding(NetNamedPipeSecurityMode.None), EndpointUri);
            var singletonProgram = factory.CreateChannel();
            singletonProgram.CallWithArguments(Environment.GetCommandLineArgs());
        }
        private void StartService()
        {
            m_serviceHost = new ServiceHost(typeof(SingletonProgram));
            m_serviceHost.AddServiceEndpoint(
                typeof(ISingletonProgram),
                new NetNamedPipeBinding(NetNamedPipeSecurityMode.None),
                EndpointUri);
            m_serviceHost.Open();
        }
        protected override void OnExit(ExitEventArgs e)
        {
            if (m_serviceHost != null)
                m_serviceHost.Close();
            m_mutex.Dispose();
            base.OnExit(e);
        }
    }
