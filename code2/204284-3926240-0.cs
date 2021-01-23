        class Program
        {
            // map names in the XML to the names of SessionInfo properties;
            // you'll need to update this when you add a new property to
            // the SessionInfo class:
            private static Dictionary<string, string> PropertyMap = 
                new Dictionary<string, string>
            {
                {"field1", "StringProperty1"},
                {"field2", "IntProperty1"},
                {"field3", "BoolProperty1"},
            };
            // map CLR types to XmlConvert methods; you'll need one entry in
            // this map for every CLR type SessionInfo uses
            private static Dictionary<Type, Func<string, object>> TypeConverterMap = 
                new Dictionary<Type, Func<string, object>>
            {
                { typeof(bool), x => XmlConvert.ToBoolean(x)},
                { typeof(int), x => XmlConvert.ToInt32(x)},
                { typeof(string), x => x},
            };
            static void Main(string[] args)
            {
                // map SessionInfo's property names to their PropertyInfo objects
                Dictionary<string, PropertyInfo> properties = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(x => x.GetExportedTypes())
                    .Where(x => x.Name == "SessionInfo")
                    .SelectMany(x => x.GetMembers())
                    .Where(x => x.MemberType == MemberTypes.Property)
                    .Cast<PropertyInfo>()
                    .ToDictionary(x => x.Name);
                string xml =
                    @"<example>
    <row>
        <name>field1</name>
        <value>stringProperty</value>
    </row>
    <row>
        <name>field2</name>
        <value>123</value>
    </row>
    <row>
        <name>field3</name>
        <value>true</value>
    </row>
    </example>";
                XmlDocument d = new XmlDocument();
                d.LoadXml(xml);
                SessionInfo s = new SessionInfo();
                // populate the object's properties from the values in the XML
                foreach (XmlElement elm in d.SelectNodes("//row"))
                {
                    string name = elm.SelectSingleNode("name").InnerText;
                    string value = elm.SelectSingleNode("value").InnerText;
                    // look up the property for the name in the XML and get its
                    // PropertyInfo object
                    PropertyInfo pi = properties[PropertyMap[name]];
                    // set the property to the value in the XML, using the the converter for 
                    // the property's type
                    pi.SetValue(s, TypeConverterMap[pi.PropertyType](value), null);
                }
                // and the results:
                Console.WriteLine(s.StringProperty1);
                Console.WriteLine(s.IntProperty1);
                Console.WriteLine(s.BoolProperty1);
                Console.ReadKey();
            }
