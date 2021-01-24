    public static class PeriodicHealthCheckFunction
    {
        private static HttpClient _httpClient = new HttpClient();
    
        [FunctionName("PeriodicHealthCheckFunction")]
        public static async Task Run(
            [TimerTrigger("0 */5 * * * *")]TimerInfo healthCheckTimer,
            ILogger log)
        {
            string status = await _httpClient.GetStringAsync("https://localhost:5001/healthcheck");
    
            log.LogInformation($"Health check performed at: {DateTime.UtcNow} | Status: {status}");
        }
    }
