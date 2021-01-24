    [FunctionName("ConsumeNewClient")]
    public async Task EntryPoint(
            [ServiceBusTrigger(queueName:LocalSettings.AvaloqServiceBusConfigurationValues.Queue, Connection = "ServiceBusConnection")]
            string ceSbMsg, 
            [OrchestrationClient] 
            DurableOrchestrationClient starter, 
            ILogger log) {
        var instanceId = await starter.StartNewAsync("PolicyOrchestrator", ceSbMsg);
        _logger.LogInformation(0, $"[Interfaces.Avaloq.Presentation.AzureFunctions.ConsumeNewClient] - Started orchestration with ID = '{instanceId}'.");
    }
