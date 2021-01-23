    public static class XElementExtensions
    {
        public static bool AsBoolean(this XElement self, bool default)
        {
            if (self == null)
            {
                return default;
            }
            if (self.Value != null)
            {
                return XmlConvert.ToBoolean(self.Value);
            }
            return default;
        }
    }
