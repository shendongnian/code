    public class ParameterAuthorizationService : IParameterAuthorizationService
    {
        //...
        private readonly TelemetryClient _telemetryClient;
        public ParameterAuthorizationService(HttpClient httpClient, JsonSerializer jsonSerializer)
        {
            //...
            _telemetryClient = new TelemetryClient();
        }
        public async Task<string> AuthorizeUserParameterAsync(int parameterId, string authorizationHeader)
        {
            var startTime = DateTime.UtcNow;
            var timer = Stopwatch.StartNew();
            var isSuccess = true;
            try
            {
                return await AuthorizeUserParameterImpl(parameterId, authorizationHeader);
            }
            catch (Exception ex)
            {
                timer.Stop();
                isSuccess = false;
                _telemetryClient.TrackException(ex);
                _telemetryClient.TrackDependency("Http", nameof(ParameterAuthorizationService), nameof(AuthorizeUserParameterAsync),
                    startTime, timer.Elapsed, isSuccess);
                throw;
            }
            finally
            {
                if (timer.IsRunning)
                    timer.Stop();
                if (isSuccess)
                    _telemetryClient.TrackDependency(
                    "Http", nameof(ParameterAuthorizationService), nameof(AuthorizeUserParameterAsync),
                    startTime, timer.Elapsed, isSuccess);
            }                
        }
        private async Task<string> AuthorizeUserParameterImpl(int parameterId, string authorizationHeader)
        {
            //Your original code
        }
    }
