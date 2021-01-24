    public static class OnSchedulingToMMMQueueTriggered
    {
        [FunctionName("OnSchedulingToMMMQueueTriggered")]
        public static void Run(
            [QueueTrigger("httpqueue", Connection = "OnSchedulingToMMMQueueTriggered:SourceQueueConnection")] Payload myQueueItem,
            [Blob("processed/{CorrelationId}", FileAccess.Write, Connection = "OnSchedulingToMMMQueueTriggered:ProcessedPayloadsConnectionString")] out string processedPayload,
    		[Blob("success", FileAccess.Write, Connection = "OnSchedulingToMMMQueueTriggered:ProcessedPayloadsConnectionString"))] CloudBlobContainer outputSuccessContainer,
            ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem.Body}");
    
            processedPayload = "this shoudl be the body of the string";
    		
    		if (outputNeeded) {
    		    var blockBlob = outputSuccessContainer.GetBlockBlobReference(CorrelationId + ".txt");
                await blockBlob.UploadText(processedPayload);
                blockBlob.Properties.ContentType = "text/plain";
                blockBlob.SetProperties();
    		}
        }
    }
