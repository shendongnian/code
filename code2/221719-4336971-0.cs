    public static class XmlExtensions
    {
        public static T AttributeValueOrDefault<T>(this XElement element, string attributeName, T defaultValue)
        {
            var attribute = element.Attribute(attributeName);
            if (attribute != null && attribute.Value != null)
            {
                return (T)Convert.ChangeType(attribute.Value, typeof(T));
            }
            return defaultValue;
        }
    }
