    public static class XElementExtensions
    {
        public static bool AsBoolean(this XElement self, bool defaultValue)
        {
            if (self == null)
            {
                return defaultValue;
            }
            if (!string.IsNullOrEmpty(self.Value))
            {			
                try
                {
                    return XmlConvert.ToBoolean(self.Value);
                }
                catch
                {
                    return defaultValue;
                }
            }
            return defaultValue;
        }
    }
