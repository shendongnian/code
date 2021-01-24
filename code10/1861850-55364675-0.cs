    public async Task<IEnumerable<object>> GetDemographicGroupsDelegateAsync(object client, string connectionId, TardiisServiceParameters parameters = null)
    {
        var test = Convert(client.GetType().GetMethod("GetDemographicGroupsAsync").Invoke(client, new object[] { connectionId }));
        var task = await test;
        var taskResult = await task;
        return taskResult.Cast<object>();
    }
