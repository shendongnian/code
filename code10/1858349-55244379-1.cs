        public static class XHelper
        {
            public static TResponse Execute(
                string metodo, TRequest request, IConfiguracion config)
            {
                if (config == null) throw new ArgumentNullException("config");
            
                string y = config.apiUrl;  //i need it
                return xxx; //xxxxx
            }
        }
