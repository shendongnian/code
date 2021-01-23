    public interface ISiteSettings
    {
        public List<LanguageBranch> GetEnabledSiteLanguages()
    }
    
    public class ActualSiteSettings : ISiteSettings
    {
        public List<LanguageBranch> GetEnabledSiteLanguages()
        {
             return SiteSettings.GetEnabledSiteLanguages();
        }
    }
