      class Program
      {
        static void Main(string[] args)
        {
          var webServiceHhost = new WebServiceHost(typeof(AppCmdService), new Uri("http://localhost:7654"));
          ServiceEndpoint ep = webServiceHhost.AddServiceEndpoint(typeof(AppCmdService), new WebHttpBinding(), "");
          var serviceDebugBehavior = webServiceHhost.Description.Behaviors.Find<ServiceDebugBehavior>();
          serviceDebugBehavior.HttpHelpPageEnabled = false;
          webServiceHhost.Open();
          Console.WriteLine("Service is running");
          Console.WriteLine("Press enter to quit ");
          Console.ReadLine();
          webServiceHhost.Close(); 
        }
      }
