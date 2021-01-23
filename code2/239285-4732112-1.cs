    public class Session
        {        
    
            private const string _skyWardsNumber = "skyWardsNumber";
            // Add other keys here
    
            public string SkyWardsNumber
            {
                get
                {
                    object str = (ReadFromDictionary(_skyWardsNumber);
                    if (str != null)
                    {
                        return (string) str;
                    }
                    else
                    {
                        return string.Empty;
                    }
                   
                }
                set
                {
                    WriteToDictionary(_skyWardsNumber, value);
                }
            }
    
            public object ReadFromDictionary(string key)
            {
                IDictionary dictionary = (ReadFromContext("Dictionary") as IDictionary);
                if (dictionary != null && dictionary.ContainsKey(key))
                {
                   return dictionary[key];
                }
                else
                {
                   return null;
                }
            }
            
            public object WriteFromDictionary(string key, object value)
            {
                IDictionary dictionary = (ReadFromContext("Dictionary") as IDictionary);
                
                if(dictionary == null)
                     WriteToContext("Dictionary", new Dictionary<string, string>())
    
                dictionary = (ReadFromContext("Dictionary") as IDictionary);
    
                if (dictionary.ContainsKey(key))
                {
                   dictionary[key] = value;
                }
                else
                {
                   dictionary.Add(//add new keyvaluepair.);
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
