    public class Fraction: IXmlSerializable 
    {
        private Fraction()
        {
        }
        public Fraction(int numerator, int denominator)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }
        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }
        public void ReadXml(XmlReader reader)
        {
            var content = reader.ReadInnerXml();
            var parts = content.Split('/');
            Numerator = int.Parse(parts[0]);
            Denominator = int.Parse(parts[1]);
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteRaw(this.ToString());
        }
        public override string ToString()
        {
            return string.Format("{0}/{1}", Numerator, Denominator);
        }
    }
    [DataContract(Name = "Object", Namespace="")]
    public class MyObject
    {
        [DataMember]
        public Fraction Frac { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myobject = new MyObject
            {
                Frac = new Fraction(1, 2)
            };
            var dcs = new DataContractSerializer(typeof(MyObject));
            string xml = null;
            using (var ms = new MemoryStream())
            {
                dcs.WriteObject(ms, myobject);
                xml = Encoding.UTF8.GetString(ms.ToArray());
                Console.WriteLine(xml);
                // <Object><Frac>1/2</Frac></Object>
            }
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                ms.Position = 0;
                var obj = dcs.ReadObject(ms) as MyObject;
                Console.WriteLine(obj.Frac);
                // 1/2
            }
        }
    }
