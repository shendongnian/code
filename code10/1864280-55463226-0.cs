    public static class OnSchedulingToMMMQueueTriggered {
        [FunctionName("OnSchedulingToMMMQueueTriggered")]
        public static async Task RunAsync(
            [QueueTrigger("httpqueue", Connection = "OnSchedulingToMMMQueueTriggered:SourceQueueConnection")] Payload myQueueItem,
            [Blob("processed/{CorrelationId}", FileAccess.Write, Connection = "OnSchedulingToMMMQueueTriggered:ProcessedPayloadsConnectionString")]  Stream processedPayload,
            Binder binder, //<--NOTE *Binder* not *IBinder*
            ILogger log) {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem.Body}");
            var attributes = new Attribute[] {
                new BlobAttribute("success/{CorrelationId}"),
                new StorageAccountAttribute("MyStorageAccount")
            };
            using (var writer = await binder.BindAsync<TextWriter>(attributes)) {
                writer.Write(JsonConvert.SerializeObject(myQueueItem.Body));
            }
        }
    }
