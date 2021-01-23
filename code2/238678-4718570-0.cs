    public class EpochTime
    {
        [XmlText]
        public double Data { get; set; }
        [XmlAttribute("type")]
        public string Type { get; set; }
    }
    
    public class Foo
    {
        public EpochTime Time { get; set; }
    }
    
    class Program
    {
        public static void Main()
        {
            var foo = new Foo
            {
                Time = new EpochTime
                {
                    Data = 1295027809.26896,
                    Type = "epoch_seconds"
                }
            };
            var serializer = new XmlSerializer(foo.GetType());
            serializer.Serialize(Console.Out, foo);
        }
    }
