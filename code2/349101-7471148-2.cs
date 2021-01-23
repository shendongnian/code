    public class DependentClass
    {
        private ISiteSettings m_siteSettings;
        public DependentClass(ISiteSettings siteSettings)
        {
        m_siteSettings=siteSettings;
        }
    
        public void SomeMethod
        {
             var siteLanguages = from sl in m_siteSettings.GetEnabledSiteLanguages() select sl.LanguageID;
        }
    }
