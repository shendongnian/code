    public class ChildActionOutputCacheAttribute : OutputCacheAttribute
    {
        private const string _cachingSection = "system.web/caching/";
        private const string _outputCacheSection = "outputCache";
        private const string _profileSection = "outputCacheSettings";
        private bool _profileEnabled;
        public ChildActionOutputCacheAttribute(string cacheProfile)
        {
            // get output cache section of web config
            OutputCacheSection settings = (OutputCacheSection)WebConfigurationManager.GetSection($"{_cachingSection}{_outputCacheSection}");
            // check section exists and caching is enabled
            if (settings != null && settings.EnableOutputCache)
            {
                // if caching enabled, get profile
                OutputCacheSettingsSection profileSettings = (OutputCacheSettingsSection)WebConfigurationManager.GetSection($"{_cachingSection}{_profileSection}");
                OutputCacheProfile profile = profileSettings.OutputCacheProfiles[cacheProfile];
                if (profile != null && profile.Enabled)
                {
                    // if profile exits set profile params
                    Duration = profile.Duration;
                    VaryByParam = profile.VaryByParam;
                    VaryByCustom = profile.VaryByCustom;
                    _profileEnabled = true;           // set profile enable to true as output cache is turned on and there is a profile
                }
            }
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (_profileEnabled)
            {
                // only run this if caching has been set and is enabled
                base.OnActionExecuting(filterContext);
            }
        }
    }
