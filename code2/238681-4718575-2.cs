    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    static class Program
    {
        static void Main()
        {
            Foo foo;
            var ser = new XmlSerializer(typeof(Foo));
            using (var reader = XmlReader.Create(new StringReader(@"<foo>
       <time type=""epoch_seconds"">1295027809.26896</time>
    </foo>")))
            {
                foo = (Foo)ser.Deserialize(reader);
            }
        }
    }
    public class EpochTime
    {
        public enum TimeType
        {
            [XmlEnum("epoch_seconds")]
            Seconds
        }
        [XmlAttribute("type")]
        public TimeType Type { get; set; }
        [XmlText]
        public string Text { get; set; }
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1);
        [XmlIgnore] public DateTime Value
        {
            get
            {
                switch (Type)
                {
                    case TimeType.Seconds:
                        return Epoch + TimeSpan.FromSeconds(double.Parse(Text));
                    default:
                        throw new NotSupportedException();
                }
            }
            set {
                switch (Type)
                {
                    case TimeType.Seconds:
                        Text = (value - Epoch).TotalSeconds.ToString();
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }
        }
    }
    [XmlRoot("foo")]
    public class Foo
    {
        public Foo()
        {
        }
        [XmlElement("time")]
        public EpochTime Time { get; set; }
    }
