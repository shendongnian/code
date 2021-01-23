    using System.Runtime.Serialization;
    using System.ServiceModel;
    using MySpace;
    using System.ServiceModel.Channels;
    using System;
    namespace MySpace
    {
    
     [DataContract]
     public class Person 
      {
        public Person ()
        {
        }
        [DataMember(Name = "Name")]
        public string mName { get; set; }
        [DataMember(Name = "Age")]
        public int? mAge { get; set; }
        [DataMember(Name = "Single")]
        public bool? mIsSingle { get; set; }
      
    
    
        [System.Runtime.Serialization.OnDeserialized]
        void OnDeserialized(System.Runtime.Serialization.StreamingContext c)
        {
          mAge =  (mAge == null ? 18 : mAge);
        }
      }
    }
    [ServiceContract]
    public interface IService
    {
      [OperationContract]
      Person Method(Person dd);
    }
    
    public class Service : IService
    {
      public Person Method(Person dd)
      {
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
        Person d = new Person();
        d.mName = "BuzBuza";
    
        Console.WriteLine("Data before calling service " + (d.mAge == null ? " null " : d.mAge.Value.ToString()));
        Console.WriteLine("Data before calling service " + (d.mIsSingle == null ? "null" : d.mIsSingle.Value.ToString()));
        d = proxy.Method(d);
        fac.Close();
        host.Close();
        Console.WriteLine("Data after calling service " + (d.mAge == null ? " null " : d.mAge.Value.ToString()));
        Console.WriteLine("Data after calling service " + (d.mIsSingle == null ? "null" : d.mIsSingle.Value.ToString()));
        
        Console.ReadLine();
      }
    }
