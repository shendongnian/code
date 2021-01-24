    internal async Task TakeSnapshotAsync(ILambdaContext context, string migration) {
        var instanceId = this.GetEnvironmentVariable(nameof(DBInstance));
        //don't wrap in using block or it will be disposed before you are done with it.
        var rdsClient = new AmazonRDSClient();
        var request = new CreateDBSnapshotRequest($"{instanceId}{migration.Replace('_','-')}", instanceId);
        //don't await this long running task
        Task<CreateDBSnapshotResponse> response = rdsClient.CreateDBSnapshotAsync(request);
        Task delay = Task.Run(async () => {
            while (context.RemainingTime > TimeSpan.FromSeconds(15)) {
                await Task.Delay(15000); //Don't mix Thread.Sleep. use Task.Delay and await it.
            }
        }
        // The call returns as soon as the first operation completes, 
        // even if the others are still running.
        await Task.WhenAny(response, delay);
    }
