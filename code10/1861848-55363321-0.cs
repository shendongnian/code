        public async Task<IEnumerable<object>> GetDemographicGroupsDelegateAsync(object client, string connectionId, TardiisServiceParameters parameters = null)
    {
        var test = Convert(client.GetType().GetMethod("GetDemographicGroupsAsync").Invoke(client, new object[] { connectionId }));
        var result = await test;
        var resultado = test.Result;
        return Convert(resultado);
    }
