    public interface IConfigurationFactory<out TConfigurationSection>
    {
        TConfigurationSection GetConfiguration();
    }
    public class RFConfigurationFactory : IConfigurationFactory<IRFConfigurationSection>
    {
        public IRFConfigurationSection GetConfiguration()
        {
            return ConfigurationManager.GetSection("userSettings/ABZReportFactoryServer") as RFConfigurationSection;
        }
    }
