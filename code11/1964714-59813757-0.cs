    public static ExampleClass DeserializeData(string content)
        {
            try
            {
                return JsonConvert.DeserializeObject<ExampleClass>(content);
            }
            catch
            {
                // If it's in this section, it's trying to deconvert outdated JSON
                Dictionary<string, dynamic> objectMap = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(content);
                Dictionary<string, PropertyInfo> propertyMap = new Dictionary<string, PropertyInfo>();
                ExampleClass data = new ExampleClass();
                foreach (PropertyInfo property in typeof(ExampleClass).GetProperties())
                    propertyMap.Add(property.Name, property);
                foreach (KeyValuePair<string, dynamic> kvp in objectMap)
                {
                    Type propertyType = propertyMap[kvp.Key].PropertyType;
                    if (kvp.Key != "CustomProperty")
                    {
                        if (kvp.Value is Array || kvp.Value is JArray)
                        {
                            Type recipientType = propertyType.GetElementType();
                            Type listType = typeof(List<>).MakeGenericType(recipientType);
                            System.Collections.IList itemList = (System.Collections.IList)Activator.CreateInstance(listType);
                            foreach (var item in (kvp.Value as JArray))
                                itemList.Add(Convert.ChangeType(item, recipientType));
                            Array itemArray = Array.CreateInstance(recipientType, itemList.Count);
                            itemList.CopyTo(itemArray, 0);
                            propertyMap[kvp.Key].SetValue(data, itemArray);
                        }
                        else if (Nullable.GetUnderlyingType(propertyType) != null)
                        {
                            propertyMap[kvp.Key].SetValue(data, Convert.ChangeType(kvp.Value, Nullable.GetUnderlyingType(propertyType)));
                        }
                        else
                            propertyMap[kvp.Key].SetValue(data, Convert.ChangeType(kvp.Value, propertyType));
                    }
                    else
                    {
                        if (kvp.Value is string)
                        {
                            propertyMap[kvp.Key].SetValue(data, new Dictionary<string, string[]>() { { "DEFAULT", (kvp.Value as string).Split('&') } });
                        }
                        else
                            propertyMap[kvp.Key].SetValue(data, kvp.Value);
                    }
                }
                return data;
            }
        }
