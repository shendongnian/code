    public class Site: ConfigurationSection
    {
        [ConfigurationProperty("pages")]
        public PageCollection Page
        {
            get
            {
                return base["pages"] as PageCollection;
            }
        }
    }
