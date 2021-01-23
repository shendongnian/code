    public static class XElementExtensions
    {
        public static bool AsBoolean(this XElement self)
        {
            if (self.Value != null)
            {
                return XmlConvert.ToBoolean(self.Value);
            }
            return false; // default value
        }
    }
