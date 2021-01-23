     public partial class App : Application
      {
            public App()
            {                
            }
 
            protected override void OnStartup(StartupEventArgs e)
            {
              var vCulture = new CultureInfo("de-DE");
              Thread.CurrentThread.CurrentCulture = vCulture;
              Thread.CurrentThread.CurrentUICulture = vCulture;
              CultureInfo.DefaultThreadCurrentCulture = vCulture;
              CultureInfo.DefaultThreadCurrentUICulture = vCulture;
              FrameworkElement.LanguageProperty.OverrideMetadata(
              typeof(FrameworkElement),
              new FrameworkPropertyMetadata(                 
           XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
              base.OnStartup(e);
           }
  }
