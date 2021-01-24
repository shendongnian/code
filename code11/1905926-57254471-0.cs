    public interface IHelpers<T> { }
    public class Helpers<T> : IHelpers<T>
    {
        private readonly ILogger _logger;
        public Helpers(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }
    }
