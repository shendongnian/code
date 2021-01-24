    public static void processservicebus(
            [ServiceBusTrigger("myqueue", Connection = "ServiceBusConnection")]Message message,
            ILogger log)
            {
    
                log.LogInformation(message.ContentType);
    
                XDocument orderOut = XDocument.Parse(Encoding.UTF8.GetString(message.Body));
        
            }
