    namespace Parser
    {
        // create metadata attribute
        class CsvPositionAttribute : Attribute
        {
            public int Position { get; set; }
            public CsvPositionAttribute(int position)
            {
                Position = position;
            }
        }
    
        // define some classes that use our metadata
        public class type1
        {
            [CsvPosition(0)]
            public int int1;
            [CsvPosition(1)]
            public string str1;
            [CsvPosition(2)]
            public string str2;
            [CsvPosition(3)]
            public string str3;
        }
    
        public class type2
        {
            [CsvPosition(0)]
            public int int1;
            [CsvPosition(1)]
            public int int2;
            [CsvPosition(2)]
            public string str1;
            [CsvPosition(3)]
            public string str2;
            [CsvPosition(4)]
            public string str3;
        }
    
        public class CsvParser
        {
            public static object ParseString(string input)
            {
                string[] items = input.Split(',');
                // make sure we have enough items
                if (items.Length < 2)
                    return null;
                string identifier = items[1];
                // assume that our identifiers refer to a type in our namespace
                Type type = Type.GetType("Parser." + identifier, false);
                if (type == null)
                    return null;
                object output = Activator.CreateInstance(type);
                // iterate over fields in the type -- you may want to use properties
                foreach (var field in type.GetFields())
                    // find the members that have our position attribute
                    foreach (CsvPositionAttribute attr in
                        field.GetCustomAttributes(typeof(CsvPositionAttribute),
                                                  false))
                        // if the item exists, convert it to the type of the field
                        if (attr.Position + 2 >= items.Length)
                            return null;
                        else
                            // ChangeType may throw exceptions on failure;
                            // catch them and return an error
                            try { field.SetValue(output,
                                Convert.ChangeType(items[attr.Position + 2],
                                                   field.FieldType));
                            } catch { return null; }
                return output;
            }
        }
    }
