    using System;
    using System.Collections;
    using System.Configuration;
    using System.Xml;
    using System.Collections.Specialized; 
    
    
    public class Config : ConfigurationSection
    {
        private static string _CONFIG_SECTION = "Misc";
    
        #region singleton implementation
        private static Config _config;
        static Config()
        {
            _config = (Config)ConfigurationSettings.GetConfig(_CONFIG_SECTION);
        }
        #endregion 
    
        public static bool MySetting1
        {
            get
            {
                return _config._MySetting1;
            }
        }
        
        #region public properties the define the config items we are looking for
        [ConfigurationProperty("MySetting1", IsRequired = false)]
        public bool _MySetting1
        {
            get
            {
                return (bool)this["MySetting1"];
            }
        }        
        #endregion
    } 
     
