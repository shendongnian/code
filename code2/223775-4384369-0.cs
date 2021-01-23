    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            var collection = new[]
            {
                new Item {Id = 1, ItemName = "Super Sale Item Name"}
            };
    
            var xdoc = new XDocument(new XElement("Items",
                                    collection.Select(x => new XElement("Item",
                                            new XElement("ID", x.Id),
                                            new XElement("Item_Name", x.ItemName)))));
    
            Console.WriteLine(xdoc);
        }
    }
