    [FunctionName("func1")]
    public async Task Run([ServiceBusTrigger("topic","subscription", Connection = "ServiceBusConnectionString")]
        Message message)
    {
     var id = message.CorrelationId;
    }
