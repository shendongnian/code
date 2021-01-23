     public static class ApplicationData
    {
        private static Dictionary<string, object> _someData = new Dictionary<string, object>();
        public static Dictionary<string, object> SomeData
        {
            get
            {
                return _someData;
            }
        }
    }
