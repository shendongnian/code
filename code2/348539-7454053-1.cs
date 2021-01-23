    private static void InitializeCultures()
    {
        if (!String.IsNullOrEmpty(UserSettings.Default.Culture))
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(UserSettings.Default.Culture);
        }
        if (!String.IsNullOrEmpty(UserSettings.Default.UICulture))
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(UserSettings.Default.UICulture);
        }
    
        FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(
            XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
    }
