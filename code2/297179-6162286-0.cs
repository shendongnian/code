            static String Reflect(Object data)
            {
                StringBuilder stringBuilder = new StringBuilder();
    
                foreach (PropertyInfo propertyInfo in data.GetType().GetProperties())
                {
                    if (propertyInfo.PropertyType.IsClass && propertyInfo.PropertyType != typeof(String))
                    {
                        stringBuilder.AppendFormat("{0} : {1} {2}", propertyInfo.Name, Environment.NewLine 
                            , Reflect(propertyInfo.GetValue(data, null)));
                    }
                    else
                    {
                       stringBuilder.AppendFormat("{0} = {1}, {2}", propertyInfo.Name,  propertyInfo.GetValue(data, null), Environment.NewLine);
                    }
                }
    
                return stringBuilder.ToString();
            }
