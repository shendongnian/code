     public sealed partial class MainPage
        {
            public MainPage()
            {
                 
              
                this.Loaded += (sender, args) => {
    
                    SetEnGbCulture();
               
                };
            }
    
            public void SetEnGbCulture()
            {
                CultureInfo ci = new CultureInfo("en-GB");
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
                ApplicationLanguages.PrimaryLanguageOverride = "en-GB";
                Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().Reset();
                Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse().Reset();
    
            }
        }
