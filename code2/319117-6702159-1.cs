            private T[] GetKeys<T>(string key, Dictionary<string, object> obj)
            // Since you're not using the default constructor don't need this:
            //   where T : new()
            {
                if (obj.ContainsKey(key))
                {
                    object[] objs = (object[])obj[key];
                    T[] list = new T[objs.Length];
                    for (int i = 0; i < objs.Length; i++)
                    {
                        list[i] = (T)typeof(T).GetConstructor(new [] {typeof(Dictionary<string,object>)}).Invoke (new object[] {
                                             (Dictionary<string, object>)objs[i] 
                                         });
                    }
                    return list;
                }
                else
                {
                    return null;
                }
            }
