    static void Main(string[] args)
    {
      using (ServiceHost host = new ServiceHost(typeof(YourNamespace.YourServiceInterface)))
      {
        host.AddServiceEndpoint(typeof(
    YourNamespace.YourServiceInterface), new NetTcpBinding(), "net.tcp://localhost:9000/YourService");
        host.Open();
    
        Console.WriteLine("Press <Enter> to terminate the Host 
    application.");
        Console.WriteLine();
        Console.ReadLine();
      }
    }
