    public class TestPrice
    {
        [XmlElement(ElementName = "Price")]
        public List<Price> Price { get; set; }
    }
    
    public class Price
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
    
        public List<Interval> Intervals { get; set; }
    }
    
    public class Interval
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            var xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
    <TestPrice>
      <Price>
        <A>A</A>
        <B>B</B>
        <C>C</C>
        <Intervals>
          <Interval>
            <A>A</A>
            <B>B</B>
            <C>C</C>
          </Interval>
          <Interval>
            <A>A</A>
            <B>B</B>
            <C>C</C>
          </Interval>
        </Intervals>
      </Price>
    </TestPrice>";
    
            var serializer = new XmlSerializer(typeof(TestPrice));
            using (var reader = new StringReader(xml))
            using (var xmlReader = XmlReader.Create(reader))
            { 
                var priceEntity = (TestPrice)serializer.Deserialize(xmlReader);
                foreach (var price in priceEntity.Price)
                {
                     // do something with the price
                }
            }
        }
    }
