        public class XHelper
        {
            private readonly IConfiguracion config;
            
            public XHelper(IConfiguracion config)
            {
                if (config == null) throw new ArgumentNullException("config");
                this.config = config;
            }
            public TResponse Execute(string metodo, TRequest request)
            {
                string y = this.config.apiUrl;  //i need it
                return xxx; //xxxxx
            }
        }
