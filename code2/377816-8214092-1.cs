    using System;
    using System.Runtime.Serialization;
    using System.IO;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    
    namespace MySpace
    {
    
      [DataContract]
      public class Data
      {
        [DataMember]
        public string MyString;
    
      }
      [ServiceContract]
      public interface IService
      {
        [OperationContract]
        Data Method(Data dd);
      }
    
      public class Service : IService
      {
        public Data Method(Data dd)
        {
          dd.MyString = dd.MyString + " String from Server.";
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
          Data d = new Data();
          d.MyString = "String from client.";
          d = proxy.Method(d);
          fac.Close();
          host.Close();
          Console.WriteLine("Result after calling \n " + d.MyString);
    
          Console.ReadLine();
        }
      }
    }
