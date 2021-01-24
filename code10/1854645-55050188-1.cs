    private static void IfEmptyListThenNull<T>(T myObject)
            {
                foreach (PropertyInfo propertyInfo in myObject.GetType().GetProperties())
                {
                    if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                    {
                        if (((IList)propertyInfo.GetValue(myObject, null)).Count == 0)
                        {
                            propertyInfo.SetValue(myObject, null);
                        }
                    }
                }
            }
