    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken)
    {
        using (SqlConnection connection =
           new SqlConnection(_configuration.GetConnectionString("PwdrsConnectionRoot")))
        {
            try
            {
                await connection.OpenAsync();
            }
            catch (SqlException)
            {
                return HealthCheckResult.Healthy();
            }
        }
    
        return HealthCheckResult.Healthy();
    }
