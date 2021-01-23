    [ServiceContract]
     public interface IService1
     { 
     [OperationContract]
     string GetIpAddress(string value);
     }
     public class Service1 : IService1
     {
      public string GetIpAddress()
        {
      // Add the proper error handling and collection matching of course
            IPAddress s = Dns.GetHostAddresses("www.mysite.com")[0];
            return s.ToString();
        }
      }
