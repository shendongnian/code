    public static List<T> Fill<T>(this SqlDataReader reader) where T : new()
            {
                List<T> res = new List<T>();
                while (reader.Read())
                {
                    T t = new T();
                    for (int inc = 0; inc < reader.FieldCount; inc++)
                    {
                        Type type = t.GetType();
                        string name = reader.GetName(inc);
                        PropertyInfo prop = type.GetProperty(name);
                        if (prop != null)
                        {
                            if (name == prop.Name)
                            {
                                var value = reader.GetValue(inc);
                                if (value != DBNull.Value)
    							{ 
    								prop.SetValue(t, Convert.ChangeType(value, prop.PropertyType), null);
    							}
                                //prop.SetValue(t, value, null);
                                
                            }
                        }
                    }
                    res.Add(t);
                }
                reader.Close();
    
                return res;
            }
