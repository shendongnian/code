    public interface IContextSettings
    {
        string ContextUserID { get; }
    }
    public class ContextSettings : IContextSettings
    {
        private IConfiguration configuration;
        public ContextSettings(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string ContextUserID => configuration.GetSection("AppSettings").GetSection("ContextUserID").Value;
    }
