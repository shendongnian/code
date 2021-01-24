    public partial class Service1 : ServiceBase
        {
            ServiceHost sh = new ServiceHost(typeof(MyService), new Uri("http://localhost:5900"));
            public Service1()
            {
                InitializeComponent();
            }
    
            protected override void OnStart(string[] args)
            {
                if (sh.State==CommunicationState.Opened)
                {
                    Log("Service open Fail");
                }
                else
                {
                    WebHttpBinding webHttpBinding = new WebHttpBinding();
                    ServiceEndpoint se = sh.AddServiceEndpoint(typeof(IService), webHttpBinding, "");
                    se.EndpointBehaviors.Add(new WebHttpBehavior());
                    sh.Open();
                    Log("Service is ready....");
                }
            }
    
            protected override void OnStop()
            {
                if (sh.State==CommunicationState.Opened)
                {
                    sh.Close();
                    Log("Service closed successfully");
                }
            }
            private void Log(string text)
            {
                using (StreamWriter sw=new StreamWriter(@"D:\log.txt",true))
                {
                    sw.WriteLine($"{text}----Time:{DateTime.Now.ToShortTimeString()}");
                }
            }
            [ServiceContract]
            public interface IService
            {
                [OperationContract]
                [WebGet]
                string SayHello();
            }
            public class MyService : IService
            {
                public string SayHello()
                {
                    return "Hello Stranger";
                }
            }
    }
