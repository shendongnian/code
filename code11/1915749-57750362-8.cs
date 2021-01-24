    public async Task<CloudFormationResponse> MigrateDatabase(CloudFormationRequest request, ILambdaContext context) {
        LambdaLogger.Log($"{nameof(MigrateDatabase)} invoked: " + JsonConvert.SerializeObject(request));
        if (request.RequestType != "Delete") {
            try {
                var migrations = this.Context.Database.GetPendingMigrations().OrderBy(b=>b).ToList();
                for (int i = 0; i < migrations.Count(); i++) {
                    string thisMigration = migrations [i];
                    this.ApplyMigrationInternal(thisMigration);
                }
                await this.TakeSnapshotAsync(context, migrations.Last());
                return await CloudFormationResponse.CompleteCloudFormationResponse(null, request, context);
            } catch (Exception e) {
                LambdaLogger.Log(e.ToString());
                if (e.InnerException != null) LambdaLogger.Log(e.InnerException.ToString());
                return await CloudFormationResponse.CompleteCloudFormationResponse(e, request, context);
            }
        }
        return await CloudFormationResponse.CompleteCloudFormationResponse(null, request, context);
    }
