    namespace MySpace
    {
    
      public class MyCustomClass
      {
        public string MyStrData { get; set; }
      }
    
      [DataContract]
      public class Data
      {
        [DataMember]
        public int mInt;
    
        [DataMember]
        public MyCustomClass MyCustonObj;
    
    
    
        [OnDeserialized]
        void OnDeserialized(StreamingContext c)
        {
          if (MyCustonObj == null)
          {
            MyCustonObj = new MyCustomClass();
            MyCustonObj.MyStrData = "Overridden in serialization";
          }
        }
    
        [OnDeserializing]
        void OnDeserializing(StreamingContext c)
        {
          if (MyCustonObj == null)
          {
            MyCustonObj = new MyCustomClass();
            MyCustonObj.MyStrData = "Overridden in  deserializing";
          }
        }
    
        [OnSerialized]
        void OnSerialized(StreamingContext c)
        {
    
        }
    
        [OnSerializing]
        void OnSerializing(StreamingContext c)
        {
    
        }
      }
    
    
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
        d.mInt = 5;
        Console.WriteLine("Data before calling service " + d.mInt);
        Console.WriteLine("Data before calling service " + (d.MyCustonObj == null ? "null" : d.MyCustonObj.MyStrData));
        d = proxy.Method(d);
        fac.Close();
        host.Close();
        Console.WriteLine("Data after calling service " + d.mInt);
        Console.WriteLine("Data after calling service " + d.MyCustonObj.MyStrData);
        Console.ReadLine();
      }
    }
