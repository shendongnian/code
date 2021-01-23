    public class Global : System.Web.HttpApplication
    {
        public static IBus Bus { get; private set; }
        void Application_Start(object sender, EventArgs e)
        {
            Bus = NServiceBus.Configure.WithWeb()
                .Log4Net()
                .DefaultBuilder()
                .XmlSerializer()
                .MsmqTransport()
                    .IsTransactional(false)
                    .PurgeOnStartup(false)
                .UnicastBus()
                    .ImpersonateSender(false)
                .CreateBus()
                .Start();
        } 
