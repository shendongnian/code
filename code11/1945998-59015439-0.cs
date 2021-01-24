c#
cf = factoryFactory.CreateConnectionFactory();
foreach (Endpoint e in env.GetEndpoints())
{
    Console.WriteLine("Consuming messages from endpoint {0}({1})", e.host, e.port);
    // Set the properties
    SetConnectionProperties(cf, e);
    try
    {
        ReceiveMessagesFromEndpoint(cf);
    }
    catch (XMSException ex)
    {
        Console.WriteLine("XMSException caught: {0}", ex);
        Console.WriteLine("Error Code: {0}", ex.ErrorCode);
        Console.WriteLine("Error Message: {0}", ex.Message);
        if (ex.LinkedException != null && 
                IBM.XMS.MQC.MQRC_Q_MGR_NOT_AVAILABLE.ToString().Equals(ex.LinkedException.Message))
        {
            Console.WriteLine("Queue Manager on this endpoint is not available");
            Console.WriteLine("Moving onto next endpoint");
            continue;
        }
        Console.WriteLine("Unexpected Error - Aborting");
        throw;
    }
}
