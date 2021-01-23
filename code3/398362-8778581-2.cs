    public class TabModuleSettingsWrapper {
    
       SettingsCollection _settings; // I do not know of which type your settings are.
    
       public TabModuleSettingsWrapper(SettingsCollection settings) {
           _settings = settings;
       }
    
       private string TreeModuleIDText { get { return (string)_settings["TreeModuleID"]; } }
    
       public int? TreeModuleID { 
            get { 
                int id;
                return int.TryParse(TreeModuleIDText, out id) ? id : (int?)null;
            }
       }
    
       // Repeat this for all the settings
    }
