    var backupPolicy = new BackupLongTermRetentionPolicy
    {
        WeeklyRetention = "P52W"
    };
    
    await client.BackupLongTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(
        _azureConfig.DatabaseServerResourceGroupName,
        _azureConfig.DatabaseServerName,
        databaseName, backupPolicy, null, CancellationToken.None);
