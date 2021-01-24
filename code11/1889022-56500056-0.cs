    public interface ILogsStuff
    {
        void LogSomething(string message);
    }
    public class TelemetryClientLogger : ILogsStuff, IDisposable
    {
        private readonly TelemetryClient _telemetryClient;
        public TelemetryClientLogger(TelemetryClient telemetryClient)
        {
            _telemetryClient = telemetryClient;
        }
        public void LogSomething(string message)
        {
            _telemetryClient.TrackTrace(message);
        }
        public void Dispose()
        {
            _telemetryClient.Flush();
        }
    }
