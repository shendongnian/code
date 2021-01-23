    using System;
    using System.Configuration.Install;
    using System.Xml;
    using System.IO;
    using System.Reflection;
    using System.ComponentModel;
    using System.Collections;
    
    namespace ClassLibrary1
    {
        [RunInstaller(true)]
        public partial class Installer1 : System.Configuration.Install.Installer
        {
            public Installer1()
            {
                InitializeComponent();
            }
    
            [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
            public override void Commit(IDictionary savedState)
            {
                base.Commit(savedState);
                System.Diagnostics.Process.Start(ConfigurationManager.AppSettings["launch"]);
            }
        }
    
        public class ConfigurationManager
        {
            private static AppSetting _appSettings = new AppSetting();
    
            public static AppSetting AppSettings
            {
                get { return _appSettings; }
            }
    
            public class AppSetting
            {
                public string this[string key]
                {
                    get
                    {
                        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), "app.config");
                        var xpath = string.Format("/configuration/appSettings/add[@key='{0}']", key);
                        var doc = new XmlDocument();
    
                        doc.Load(path);
                        var node = doc.SelectSingleNode(xpath);
    
                        if (node == null) 
                            return string.Empty;
    
                        return node.Attributes["value"].Value;
                    }
                }
            }
        }
    }
