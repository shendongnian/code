    using NLog;
    public class DemoClass
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public void DemoMethod()
        {
            try
            {
                //some code
                _logger.Info("Some information");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Something went wrong");
                throw;
            }
        }
    }
