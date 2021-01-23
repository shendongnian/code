    static void Main(string[] args)
    {
        ServiceHost serviceHost = new ServiceHost(typeof(MyReportingServices.MyReportServices), ServiceEndpointUri);
        WebHttpBinding binding = new WebHttpBinding();
        ServiceEndpoint sep = serviceHost.AddServiceEndpoint(typeof(MyReportingServices.IMyReportServices), binding, string.Empty);
        sep.Behaviors.Add(new WebHttpBehavior());
        serviceHost.Open();
        Console.WriteLine("Service is running @ " + ServiceEndpointUri);
        Console.WriteLine();
        Console.WriteLine("Press enter to shutdown service.");
        Console.ReadLine();
        serviceHost.Close();
    }
