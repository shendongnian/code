    public class Site : ConfigurationSection
    {
        [ConfigurationProperty("pages")]
        [ConfigurationCollection(typeof(PageCollection), AddItemName="page")]
        public PageCollection pages
        {
            get
            {
                return base["pages"] as PageCollection;
            }
        }
    }
