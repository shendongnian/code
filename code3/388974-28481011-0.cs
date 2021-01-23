    public static class ExtensionMethods
    {
        public static void AddXml(this SqlParameterCollection theParameters, string name, XElement value)
        {
            theParameters.Add(new SqlParameter()
            {
                ParameterName = name,
                SqlDbType = SqlDbType.Xml,
                Value = new SqlXml(value.CreateReader())
            });
        }
        public static void AddXml(this SqlParameterCollection theParameters, string name, string value)
        {
            theParameters.Add(new SqlParameter()
            {
                ParameterName = name,
                SqlDbType = SqlDbType.Xml,
                Value = new SqlXml(XElement.Parse(value).CreateReader())
            });
        }
    }
