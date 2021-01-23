    public class MyClass
    {
        readonly ILogger _logger;
        public MyClass(ILogger logger)
        {
            _logger = logger;
        }
        public void MethodOne()
        {
            try
            {
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, withinHttpContext: false);
            }
        }
    }
