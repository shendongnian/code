    using System;
    using System.ServiceModel;
    
    namespace ConsoleApplication
    {
      class Program
      {
        static void Main(string[] args)
        {
          TimeServiceSoapClient client = 
            new TimeServiceSoapClient(
              new BasicHttpBinding(), 
              new EndpointAddress("http://www.nanonull.com/TimeService/TimeService.asmx"));
    
          Console.WriteLine(client.getCityTime("London"));
        }
      }
    }
