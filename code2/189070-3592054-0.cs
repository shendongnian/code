    class Program
    {
        static void Main()
        {
            var shoppingBag = new ShoppingBag
            {
                Items = new ShoppingBagItems
                {
                    Fruits = new List<Fruit>(new[] {
                        new Fruit { Name = "pineapple" },
                        new Fruit { Name = "kiwi" },
                    }),
                    TestAttribute = "foo"
                }
            };
            var serializer = new XmlSerializer(typeof(ShoppingBag));
            serializer.Serialize(Console.Out, shoppingBag);
        }
    }
    
    public class ShoppingBag
    {
        public ShoppingBagItems Items { get; set; }
    }
    
    public class ShoppingBagItems
    {
        [XmlElement("Fruit")]
        public List<Fruit> Fruits { get; set; }
    
        [XmlAttribute("testAttribute")]
        public string TestAttribute { get; set; }
    }
    
    public class Fruit
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
