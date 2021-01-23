    public class Post_09851985_ee54_4627_9af7_6a9505c2067f
      {
        [DataContract]
        public class Person
        {
          [DataMember]
          public string name;
          [DataMember]
          public string address;
        }
        [ServiceContract]
        public interface ITest
        {
          [OperationContract]
          Person Echo(Person person);
        }
        [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
        public class Service : ITest
        {
          public Person Echo(Person person)
          {
            return person;
          }
        }
        public static void SingleHost()
        {
          string baseAddressHttp = "http://" + Environment.MachineName + ":8000/Service";
          string baseAddressTcp = "net.tcp://" + Environment.MachineName + ":8008/Service";
          ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddressHttp), new Uri(baseAddressTcp));
          host.AddServiceEndpoint(typeof(ITest), new BasicHttpBinding(), "basic");
          host.AddServiceEndpoint(typeof(ITest), new NetTcpBinding(SecurityMode.None), "tcp");
    
          host.Description.Behaviors.Add(new ServiceMetadataBehavior());
          host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
          host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
    
          host.Open();
          Console.WriteLine("Host opened");
    
          Console.WriteLine("Press ENTER to close");
          Console.ReadLine();
    
          host.Close();
        }
        public static void TwoHosts()
        {
          string baseAddressHttp = "http://" + Environment.MachineName + ":8000/Service";
          string baseAddressTcp = "net.tcp://" + Environment.MachineName + ":8008/Service";
          ServiceHost httpHost = new ServiceHost(typeof(Service), new Uri(baseAddressHttp));
          ServiceHost tcpHost = new ServiceHost(typeof(Service), new Uri(baseAddressTcp));
          httpHost.AddServiceEndpoint(typeof(ITest), new BasicHttpBinding(), "basic");
          tcpHost.AddServiceEndpoint(typeof(ITest), new NetTcpBinding(SecurityMode.None), "tcp");
    
          httpHost.Description.Behaviors.Add(new ServiceMetadataBehavior());
          tcpHost.Description.Behaviors.Add(new ServiceMetadataBehavior());
          httpHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
          tcpHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
    
          httpHost.Open();
          tcpHost.Open();
          Console.WriteLine("Host opened");
    
          Console.WriteLine("Press ENTER to close");
          Console.ReadLine();
    
          httpHost.Close();
          tcpHost.Close();
        }
        public static void Test()
        {
          TwoHosts();
        }
      }
