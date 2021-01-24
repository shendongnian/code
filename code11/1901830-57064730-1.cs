    private static void Main()
    {
        var message = @"CorrelationId: b99fb632-78cf-4910-ab23-4f69833ed2d9
                Request for API: /api/acmsxdsreader/readpolicyfrompolicyassignment Caller:C2F023C52E2148C9C1D040FBFAC113D463A368B1 CorrelationId: b99fb632-78cf-4910-ab23-4f69833ed2d9 RequestedSchemas: {urn:schema:Microsoft.Rtc.Management.Policy.Voice.2008}VoicePolicy, {urn:schema:Microsoft.Rtc.Management.Policy.Voice.2008}OnlineVoiceRoutingPolicy,  TenantId: 7a205197-8e59-487d-b9fa-3fc1b108f1e5";
        var messageData = MessageData.Parse(message);
        // Now we can access any property
        Console.WriteLine(messageData.CorrelationId);
        Console.WriteLine(messageData.RequestForAPI);
        Console.WriteLine(messageData.RequestedSchemas);
        Console.WriteLine(messageData.Caller);
        Console.WriteLine(messageData.TennantId);
        Console.ReadKey();
    }
