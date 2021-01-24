    public async Task<IEnumerable<Devices>> GetPreviousDevicesAsync(string token)
    {
        Task<IEnumerable<Devices>> deviceTask;
        using (var connection = _dbConnectionFactory.CreateConnection())
        {
            deviceTask = connection.FindAsync<Devices>(statement => statement
                .Where($"{nameof(Devices.Token)} = '{token}');
        }
       return await deviceTask; 
    }
