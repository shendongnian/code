    public class Profiles : ConfigurationSection
    {
        [ConfigurationProperty("Profile")]
        public ProfileCollection Profile
        {
            get
            {
                return this["profile"] as ProfileCollection;
            }
        }
    }    
