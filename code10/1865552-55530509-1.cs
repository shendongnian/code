    static void Main(string[] args)
    {
        ServiceReference1.ServiceClient client = new ServiceReference1.ServiceClient();
        try
        {
            client.Delete(-3);
        }
        catch (FaultException fault)
        {
            Console.WriteLine(fault.Reason.GetMatchingTranslation().Text);
        }
    }
