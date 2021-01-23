    public class ConnectionManager
    {
        public string Something
        {
            get
            {
                 // TODO: check to make sure the configuration exists and throw an exception perhaps
                 return ConfigurationSettings.ConnectionStrings["something"].ConnectionString;
            }
        }
    }
