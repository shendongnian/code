    using System;
    using System.Runtime.Serialization;
    using System.IO;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    
    namespace MyClient
    {
      [ServiceContract]
      public interface IService
      {
        [OperationContract]
        string Method(string dd);
      }
    }
    
    namespace MyServer
    {
      [ServiceContract]
      public interface IService
      {
        [OperationContract]
        string Method(string dd);
      }
    }
    
    namespace MySpace
    {  
      public class Service :MyServer.IService
      {
        public string Method(string dd)
        {
          dd  =dd+ " String from Server.";
          return dd;
        }
      }
    
      class Program
      {
        static void Main(string[] args)
        {
          string Url = "http://localhost:8000/";
          Binding binding = new BasicHttpBinding();
          ServiceHost host = new ServiceHost(typeof(Service));
          host.AddServiceEndpoint(typeof(MyServer.IService), binding, Url);
          host.AddDefaultEndpoints();
          host.Open();
    
          ChannelFactory<MyClient.IService> fac = new ChannelFactory<MyClient.IService>(binding);
          fac.Open();
          MyClient.IService proxy = fac.CreateChannel(new EndpointAddress(Url));
    
    
          string d = proxy.Method("String from client.");
          fac.Close();
          host.Close();
          Console.WriteLine("Result after calling \n " + d);
    
          Console.ReadLine();
    
          Console.ReadLine();
        }
      }
    }
