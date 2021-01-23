    private void ChangeAppSettings(string key, string NewValue) 
    { 
    Configuration cfg; 
    cfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~"); 
    
    KeyValueConfigurationElement setting = (KeyValueConfigurationElement)cfg.AppSettings.Settings(key); 
    
    if ((setting != null)) { 
    setting.Value = NewValue; 
    cfg.Save(); 
    } 
    }
