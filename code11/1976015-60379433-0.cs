    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
    
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=192.168.0.224;Initial Catalog=My_Database_Development;Integrated" +
            " Security=True")]
        public string MyDatabaseConnectionString {
            get {
                return ((string)(this["MyDatabaseConnectionString"]));
            }
        }
    } 
    
The changed part was as follows:
       public string MyDatabaseConnectionString {
            get {
                //return ((string)(this["MyDatabaseConnectionString"])); // <-- this is the cause of the trouble!
                return getConnectionString();
            }
        }
        private string getConnectionString()
        {
            // This is a method I wrote elsewhere in my program which always queries the app.config file
            return ConnectionStringUtility.GetConnectionString();
        }
Note: I have in my program a utility class containing a method that returns the connection string, so I was able to just call my utility class here in the Settings.Designer.cs
**Summary**
It's a very strange situation that only occurs when compiling a C# project containing a DataSet (XSD) to DLL.
The solution was to override the call to get the connection string in Settings.designer.cs
