    using System.IO;
    using System.Xml.Serialization;
    class Program
    {
        static void Main(string[] args)
        {
            var xml = @"<?xml version='1.0' encoding='utf-8' ?>
                <Model>
                    <Points>
                        <Point name='P1' pressure='1'>
                            <Fractions>
                                <Fraction id='aaa' value='0.15272159'/>
                                <Fraction id='bbb' value='0.15272159'/>
                            </Fractions>
                        </Point>
                    </Points>
                </Model>";
            var model = DeserializeObject<Model>(xml);
        }
        private static T DeserializeObject<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var tr = new StringReader(xml))
            {
                return (T)serializer.Deserialize(tr);
            }
        }
    }
    public class Model
    {
        [XmlArrayItem("Point")]
        public Point[] Points { get; set; }
    }
    public class Point
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "pressure")]
        public int Pressure { get; set; }
        [XmlArrayItem("Fraction")]
        public Fraction[] Fractions { get; set; }
    }
    public class Fraction
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public double Value { get; set; }
    }
