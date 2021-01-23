    public class TabModuleSettingsWrapper {
    
       private SettingsCollection _settings; // I do not know of which type your settings are.
    
       public TabModuleSettingsWrapper(SettingsCollection settings) {
           _settings = settings;
       }
    
       public int? TreeModuleID { 
            get { 
                string s = (string)_settings["TreeModuleID"];
                int id;
                return Int32.TryParse(s, out id) ? id : (int?)null;
            }
       }
    
       // Repeat this for all the settings
    }
