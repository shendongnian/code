    private HealthCheckResult CheckHealthImpl(HealthCheckContext context,
        CancellationToken cancellationToken)
    {
        using (SqlConnection connection =
           new SqlConnection(_configuration.GetConnectionString("PwdrsConnectionRoot")))
        {
            try
            {
                connection.Open();
            }
            catch (SqlException)
            {
                return HealthCheckResult.Healthy();
            }
        }
        return HealthCheckResult.Healthy();
    }
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            return Task.FromResult(CheckHealthImpl(context, cancellationToken));
        }
        catch (Exception e)
        {
            return Task.FromException(e);
        }
    }
