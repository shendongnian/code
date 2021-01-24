    public class MassTransitConsoleHostedService :
        IHostedService
    {
        readonly IBusControl _bus;
        public MassTransitConsoleHostedService(IBusControl bus, ILoggerFactory loggerFactory)
        {
            _bus = bus;
            if (loggerFactory != null && MassTransit.Logging.Logger.Current.GetType() == typeof(TraceLogger))
                MassTransit.ExtensionsLoggingIntegration.ExtensionsLogger.Use(loggerFactory);
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _bus.StartAsync(cancellationToken).ConfigureAwait(false);
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return _bus.StopAsync(cancellationToken);
        }
    }
