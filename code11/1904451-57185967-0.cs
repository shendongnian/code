    public class DeleteDailyBlobs {
        private readonly IBlobService blobService;
    
        public DeleteDailyBlobs(IBlobService blobService) {
            this.blobService = blobService;
        } 
    
        [FunctionName("DeleteDailyBlobs")]
        public async Task Run([TimerTrigger("0/3 * * * * *")] TimerInfo myTimer, ILogger log) {
            if (await blobService.PerformTasks()) {
                log.LogInformation(SuccessMessages.FunctionExecutedSuccessfully);
            }
            else {
                log.LogError(ErrorMessages.SomethingBadHappened);
            }
        }
    }
