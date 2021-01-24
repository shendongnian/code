    using SslLabsLib.Enums;
    using SslLabsLib;
    
    public static void TLSChecker(string urlString)
    {
        
        SslLabsClient client = new SslLabsClient();                                 
        // Get ipaddress and host
        var analysis = client.GetAnalysis(urlString, 24, AnalyzeOptions.Publish);
        Console.WriteLine(analysis.Host);            
        
        foreach (var item in analysis.Endpoints)
        {
            Console.WriteLine(item.IpAddress);
                                    
           var endpointanalysis = client.GetCachedEndpointAnalysis(analysis.Host, IPAddress.Parse(item.IpAddress));
            // get protocol list
            foreach (var protocol in endpointanalysis.Details.Protocols)
            {
                Console.WriteLine(protocol.Id);
                Console.WriteLine(protocol.Name);
                Console.WriteLine(protocol.Version);                    
            }                
        }
