    public class ApplicationContext
    {
        // Private constructor to prevent instantiation except through Current property.
        private ApplicationContext() {}
        
        public static ApplicationContext Current
        {
            get
            {
                ApplicationContext current = 
                     HttpContext.Current.Items["AppContext"] as ApplicationContext;
                if (current = null)
                {
                    current = new ApplicationContext();
                    HttpContext.Current.Items["AppContext"] = current;
                }
                return current;
            }
        }
        public void SetSessionValue<T>(string key, T value) 
        { 
            HttpContext.Current.Session[key] = value; 
        }
        ... etc  ... 
    }  
