    public class MyDeserializer
    {
        public static string PopulateObject(string[] jsonStrings)
        {
            Dictionary<string, object> fullEntity = new Dictionary<string, object>();
            if (jsonStrings != null && jsonStrings.Length > 0)
            {
                for (int i = 0; i < jsonStrings.Length; i++)
                {
                    
                    var myEntity = JsonSerializer.Parse<Dictionary<string, object>>(jsonStrings[i]);
                    foreach (var key in myEntity.Keys)
                    {
                        if (!fullEntity.ContainsKey(key))
                        {
                            fullEntity.Add(key, myEntity[key]);
                        }
                        else
                        {
                            fullEntity[key] = myEntity[key];
                        }
                    }
                }
            }
            return JsonSerializer.ToString(fullEntity);
        }    
    }
