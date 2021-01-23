    public class TabModuleSettingsWrapper {
    
       SettingsCollection _settings; // I do not know of which type your settings are.
    
       public TabModuleSettingsWrapper(SettingsCollection settings) {
           _settings = settings;
       }
    
       public string TreeModuleIDText { get { return (string)Settings["TreeModuleID"]; } }
    
       public int TreeModuleID { get { return int.Parse(TreeModuleIDText); } }
    
       // Repeat this for all the settings
    }
