        public class XHelper
        {
            private readonly IConfiguracion config;
            
            public XHelper(IConfiguracion config)
            {
                this.config = config ?? throw new ArgumentNullException(nameof(config));
            }
            public TResponse Execute(string metodo, TRequest request)
            {
                string y = this.config.apiUrl;  //i need it
                return xxx; //xxxxx
            }
        }
