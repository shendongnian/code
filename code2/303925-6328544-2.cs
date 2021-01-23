    [Serializable]
    public class TestDate
    {
        [XmlIgnore]
        public DateTime Date { get; set; }
        [XmlElement]
        public String ProxyDate
        {
            get { return Date.ToString("D"); }
            set { Date = DateTime.Parse(value); }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            TestDate date = new TestDate()
            {
                Date = DateTime.Now
            };
            XmlSerializer serializer = new XmlSerializer(typeof(TestDate));
            serializer.Serialize(Console.Out, date);
        }
    }
