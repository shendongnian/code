    public class MyAppConfigSettings
    {
        public string MyConstant { get; private set; }
        public MyAppConfigSettings()
        {
            MyConstant = ConfigurationManager.AppSettings["myconst"];
        }
    }
