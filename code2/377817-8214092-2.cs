    using System;
    using System.Runtime.Serialization;
    using System.IO;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    
    namespace MySpace
    {
      [ServiceContract]
      public interface IService
      {
        [OperationContract]
        string Method(string dd);
      }
    
      public class Service : IService
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
          host.AddServiceEndpoint(typeof(IService), binding, Url);
          host.Open();
          ChannelFactory<IService> fac = new ChannelFactory<IService>(binding);
          fac.Open();
          IService proxy = fac.CreateChannel(new EndpointAddress(Url));
         
         
          string d = proxy.Method("String from client.");
          fac.Close();
          host.Close();
          Console.WriteLine("Result after calling \n " + d);
    
          Console.ReadLine();
        }
      }
    }
