    internal async Task TakeSnapshotAsync(ILambdaContext context, string migration) {
        var instanceId = this.GetEnvironmentVariable(nameof(DBInstance));
        //don't wrap in using block
        var rdsClient = new AmazonRDSClient();
        //don't await this long running task
        Task<CreateDBSnapshotResponse> response = rdsClient.CreateDBSnapshotAsync(new CreateDBSnapshotRequest($"{instanceId}{migration.Replace('_','-')}", instanceId));
        while (context.RemainingTime > TimeSpan.FromSeconds(15)) {
            await Task.Delay(15000); //Don't mix Thread.Sleep. use Task.Delay and await it.
        }
    }
    
