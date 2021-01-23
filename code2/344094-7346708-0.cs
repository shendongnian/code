    foreach (var t in Cache)
            {
                System.Collections.DictionaryEntry entry = (System.Collections.DictionaryEntry)t;
                object key = entry.Key;
                object obj = Cache.GetType().GetMethod("Get", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(Cache, new object[] { key, 1 });
                PropertyInfo prop = obj.GetType().GetProperty("UtcExpires", BindingFlags.NonPublic | BindingFlags.Instance);
                DateTime expire = (DateTime)prop.GetValue(obj, null);
                Response.Write("<br/>" + key + " : " + expire);
            }
 
