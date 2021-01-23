    class RuleParser
    {
        private string _file = string.Empty;
        private string File 
        {
            get 
            {
                if(string.IsNullOrEmpty(_file))
                    _file = ConfigurationManager.AppSettings["DetectionStrategies"];
                return _file;
            }
            private set;
        }
    }
