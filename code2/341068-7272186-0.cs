    private static string xPrev = "";
            private static List<string> result;
    
            private static List<string> GetContentPropertiesInternal(Type t)
            {
                System.Reflection.PropertyInfo[] pi = t.GetProperties();
    
                foreach (System.Reflection.PropertyInfo p in pi)
                {
                    string propertyName = string.Join(".", new string[] { xPrev, p.Name });
    
                    if (!propertyName.Contains("Parent"))
                    {
                        Type propertyType = p.PropertyType;
    
                        if (!propertyType.ToString().StartsWith("MyCms"))
                        {
                            result.Add(string.Join(".", new string[] { xPrev, p.Name }).TrimStart(new char[] { '.' }));
                        }
                        else
                        {
                            xPrev = string.Join(".", new string[] { xPrev, p.Name });
                            GetContentPropertiesInternal(propertyType);
                        }
                    }
                }
    
                xPrev = "";
    
                return result;
            }
    
            public static List<string> GetContentProperties(object o)
            {
                result = new List<string>();
                xPrev = "";
    
                result = GetContentPropertiesInternal(o.GetType());
    
                return result;
            }
