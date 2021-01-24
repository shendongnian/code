            Type type = Type.GetType(AQN);
            PropertyInfo[] properties = type.GetProperties();
            var instance = (BaseClass)Activator.CreateInstance(type);
            
            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo propertyInfo = type.GetProperty(properties[i].Name);
                var propertyVal = Convert.ChangeType(yourpropertyvalue,  
                                 properties[i].PropertyType);
                propertyInfo.SetValue(instance, propertyVal);
            }
            return instance;  
