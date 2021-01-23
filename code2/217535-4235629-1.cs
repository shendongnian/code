    using System.Configuration;
    public class Settings
    {
        public int Setting1
        {
            get
            {
                return Convert.ToInt32(ConfigurationManage.AppSettings["Setting1"]);
            }
        }
        public string Setting2
        {
            get
            {
                return ConfigurationManage.AppSettings["Setting1"];
            }
        }
        ...
    }
