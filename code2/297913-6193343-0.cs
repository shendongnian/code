    using System;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.IO;
    
    
    namespace GenericManagementClasses
    {
        public class ConfigFile
        {
            private string m_ConfigFilePath;
            private XmlDocument m_XmlDoc;
    
            private FileStream fIn;
            private StreamReader sr;
            private StreamWriter sw;
    
            private OrderedDictionary m_AppSettings;
            private OrderedDictionary m_ConnectionStrings;
    
            private XmlNode m_AppSettingsNode;
            private XmlNode m_ConnectionStringsNode;
    
            #region "Properties"
            public String Path
            {
                get
                {
                    return m_ConfigFilePath;
                }
            }
    
            public OrderedDictionary AppSettings
            {
                get
                {
                    return m_AppSettings;
                }
            }
    
            public OrderedDictionary ConnectionStrings
            {
                get
                {
                    return m_ConnectionStrings;
                }
            }
            #endregion
            #region "Constructors"
            /// <summary>
            /// Default constructor - declared private so that you can't instantiate an empty ConfigFile object
            /// <code>ConfigFile cfg = new ConfigFile()</code> will result in a NotImplemented exception
            /// </summary>
            private ConfigFile()
            {
                throw new NotImplementedException("No default constructor for the ConfigFile class");
            }
            /// <summary>
            /// Public constructor
            /// <example>ConfigFile cfg = new ConfigFile(@"c:\MyApp\MyApp.exe.config");</example>
            /// </summary>
            /// <param name="ConfigFilePath">The path to the configuration file</param>
            public ConfigFile(string ConfigFilePath)
            {
                //Check to see if the file exists
                if (File.Exists(ConfigFilePath)){
                    //Initialise the XmlDocument to hold the config file
                    m_XmlDoc = new XmlDocument();
                    //Store the path to the config file
                    m_ConfigFilePath = ConfigFilePath;
    
                    //FileStream to get the contents out of the file
                    fIn = new FileStream(m_ConfigFilePath, FileMode.Open, FileAccess.ReadWrite);
                    //StreamReader to read the FileStream
                    sr = new StreamReader(fIn);
                    //StreamWriter to write to the FileStream
                    sw = new StreamWriter(fIn);
    
                    //Try and load the XML from the file stream
                    try
                    {
                        m_XmlDoc.LoadXml(sr.ReadToEnd());
                        m_AppSettingsNode = m_XmlDoc.GetElementsByTagName("appSettings")[0];
                        m_ConnectionStringsNode = m_XmlDoc.GetElementsByTagName("connectionStrings")[0];
    
                        loadAppSettings();
                        loadConnStrings();
    
                    }
                    catch (Exception ex)
                    {
                        //If it went pear shaped, throw the exception upwards
                        throw ex;
                    }
    
                }
                else
                //If the file doesn't exist, throw a FileNotFound exception
                {
                    throw new FileNotFoundException(ConfigFilePath + " does not exist");
                }
            }
            #endregion
    
            private void loadAppSettings()
            {
                m_AppSettings = new OrderedDictionary();
                XmlNodeList nl = m_AppSettingsNode.SelectNodes("add");
                foreach (XmlNode node in nl)
                {
                    m_AppSettings.Add(node.Attributes["key"].Value, node.Attributes["value"].Value);
                }
            }
    
            private void loadConnStrings()
            {
                m_ConnectionStrings = new OrderedDictionary();
    
                XmlNodeList nl = m_ConnectionStringsNode.SelectNodes("add");
                foreach (XmlNode node in nl)
                {
                    m_ConnectionStrings.Add(node.Attributes["name"].Value, node.Attributes["connectionString"].Value);
                }
            }
    
            public void setAppSetting(string name, string newValue)
            {
                if (!m_AppSettings.Contains(name))
                {
                    throw new Exception(String.Format("Setting {0} does not exist in {1}", name, m_ConfigFilePath));
                }
                else
                {
                    m_AppSettings[name] = newValue;
                    m_XmlDoc.SelectSingleNode(String.Format(@"//appSettings/add[@key='{0}']",name)).Attributes["value"].Value = newValue;
                    fIn.SetLength(0);
                    sw.Write(m_XmlDoc.InnerXml);
                    sw.Flush();
                }
    
            }
            #region "Static Methods"
            /// <summary>
            /// Static method to return a ConfigFile object
            /// <example>ConfigFile cfg = ConfigFile.LoadConfigFile(@c:\MyApp\MyApp.exe.config");"</example>
            /// </summary>
            /// <param name="ConfigFilePath">Path to the configuration file to load</param>
            /// <returns></returns>
            public static ConfigFile LoadConfigFile(string ConfigFilePath)
            {
                return new ConfigFile(ConfigFilePath);
            }
            #endregion
        }
    }
