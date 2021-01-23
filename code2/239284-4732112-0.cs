        private const string _skyWardsNumber = "skyWardsNumber";
        // Add other keys here
        public string SkyWardsNumber
        {
            get
            {
                if (ReadFromContext(_skyWardsNumber) != null)
                {
                    return (string) ReadFromContext(_skyWardsNumber);
                }
                else
                {
                    return string.Empty;
                }
               
            }
            set
            {
                WriteToContext(_skyWardsNumber, value);
            }
        }
        
        private static void WriteToContext(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }
        
        private static object ReadFromContext(string key)
        {
            if(HttpContext.Current.Session[key] != null)
                return HttpContext.Current.Session[key] as object;
             return null;
        }
        
    }
