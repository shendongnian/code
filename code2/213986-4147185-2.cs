    namespace XmlStackProblem
    {
        class Class1
        {
    
            public static void Main()
            {
                Points resultObject;
    
                XmlSerializer serializer = new XmlSerializer(typeof(Points));
                using (TextReader textReader = new StreamReader(@"d:\points.xml"))
                {
                    resultObject = serializer.Deserialize(textReader) as Points;
                }
            }
        }
    
        [Serializable]
        [XmlRoot(IsNullable = false)]
        public class Points
        {
            [XmlElementAttribute("Point")]
            public List<Point> Point
            {
                get; set;
            }
        }
    
        [Serializable]
        [XmlType(AnonymousType = true)]
        public class Point
        {
            [XmlAttribute]
            public int x
            {
                get;
                set;
            }
    
            [XmlAttribute]
            public int y { get; set; }
        }
    }
