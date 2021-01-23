    //<configSections>
    //  <sectionGroup name="elmah" type="Overflow.CustomConfigurationSectionGroup, Overflow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" >
    //  </sectionGroup>
    //</configSections>
    namespace Overflow
    {
        public class CustomSecuritySection : ConfigurationSection
        {
        }
        public class CustomConfigurationSectionGroup : ConfigurationSectionGroup
        {
            public CustomConfigurationSectionGroup()
            {
                Security = new CustomSecuritySection();
            }
            [ConfigurationProperty("security")] 
            public CustomSecuritySection Security { get; private set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var config = ConfigurationManager.OpenExeConfiguration(Path.Combine(Application.StartupPath, Application.ProductName + ".exe"));
                config.SectionGroups.Add("elmah", new CustomConfigurationSectionGroup());
                config.Save(ConfigurationSaveMode.Modified);
            }
        }
    }
