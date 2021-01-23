    public string GetEnumAttributeValue(Enum enumValue, Type attributeType, string attributePropertyName)
            {
                /* New generic version (GetEnumDescriptionAttribute results can be achieved using this new GetEnumAttribute with a call like (enumValue, typeof(DescriptionAttribute), "Description")
                 * Extracts a given attribute value from an enum:
                 *
                 * Ex:
                 * public enum X
                 * {
                         [MyAttribute(myProp = "aaaa")]
                 *       x1,
                 *       x2,
                 *       [Description("desc")]
                 *       x3
                 * }
                 *
                 * Usage:
                 *      GetEnumAttribute(X.x1, typeof(MyAttribute), "myProp") returns "aaaa"
                 *      GetEnumAttribute(X.x2, typeof(MyAttribute), "myProp") returns string.Empty
                 *      GetEnumAttribute(X.x3, typeof(DescriptionAttribute), "Description") returns "desc"
                 */
    
                var attributeObj = enumValue.GetType()?.GetMember(enumValue.ToString())?.FirstOrDefault()?.GetCustomAttributes(attributeType, false)?.FirstOrDefault();
    
                if (attributeObj == null)
                    return string.Empty;
                else
                {
                    try
                    {
                        var attributeCastedObj = Convert.ChangeType(attributeObj, attributeType);
                        var attributePropertyValue = attributeType.GetProperty(attributePropertyName)?.GetValue(attributeCastedObj);
                        return attributePropertyValue?.ToString() ?? string.Empty;
                    }
                    catch (Exception ex)
                    {
                        return string.Empty;
                    }
                }
            }
