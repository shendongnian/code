        public class XYZ
        { 
            // Some Fields
            public string X { get; set; }
            public string Y { get; set; }
            public string X { get; set; }
            
            // This will convert the passed XYZ object to JSON string
            public static string Serialize(XYZ xyz)
            {
                var serializer = new JavaScriptSerializer();
                return serializer.Serialize(xyz);
            }
            // This will convert the passed JSON string back to XYZ object
            public static XYZ Deserialize(string data)
            {
                var serializer = new JavaScriptSerializer();
                return serializer.Deserialize<XYZ>(data);
            }
        }
