     [TestClass]
        public class TestPropertyType 
        {
            public static Type GetNullableUnderlying(Type nullableType)
            {
                return Nullable.GetUnderlyingType(nullableType) ?? nullableType;
            }
    
            [TestMethod]
            public void Test_PropertyType()
            {
                var allTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes());
                var allPropertyInfos = allTypes.SelectMany(a => a.GetProperties()).ToArray();
    
                foreach (var propertyInfo in allPropertyInfos)
                {
                    var propertyType = GetNullableUnderlying(propertyInfo.PropertyType);
                    foreach (var attribute in propertyInfo.GetCustomAttributes(true))
                    {
                        var attributes = attribute.GetType().GetCustomAttributes(true).OfType<PropertyTypeAttribute>();
                        foreach (var propertyTypeAttr in attributes)
                            if (!propertyTypeAttr.Types.Contains(propertyType))
                                throw new Exception(string.Format(
                                    "Property '{0}.{1}' has invalid type: '{2}'. Allowed types for attribute '{3}': {4}",
                                    propertyInfo.DeclaringType,
                                    propertyInfo.Name,
                                    propertyInfo.PropertyType,
                                    attribute.GetType(),
                                    string.Join(",", propertyTypeAttr.Types.Select(x => "'" + x.ToString() + "'"))));
                    }
                }
            }
        }
