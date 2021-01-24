    Shared:
        public interface IRegionCulture
        {
            CultureInfo GetRegionCulture();
        }
    
    Android:
        public CultureInfo GetRegionCulture()
        {
            return new CultureInfo(Java.Util.Locale.Default.ToString());
        }
    
    iOS:
        public CultureInfo GetRegionCulture()
        {
            var code = NSLocale.CurrentLocale.CountryCode;
            var culture = CultureInfo.GetCultures(CultureTypes.AllCultures).FirstOrDefault(c => c.Name.EndsWith("-" + code, StringComparison.Ordinal));
            return culture;
        }
