    public partial class YourUC : UserControl
    {        
        public static YourUC _instance;
        public static YourUC Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new YourUC();
                return _instance;
            }
        }
    }
        
