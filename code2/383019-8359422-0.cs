    namespace XMLParser
    {
        class Program
        {
            static void Main(string[] args)
            {
                XElement items = XElement.Load(@"C:\XMLParser\items.xml");
    
                var filteredItems = from item in items.Descendants("item")
                                    select item.Element("name");
    
                foreach (var item in filteredItems)
                {
                    // Replacing " - " with NewLine
                    Console.WriteLine(item.Value.Replace(" - ",
                                                         System.Environment.NewLine));
    
                    // Only First name
                    Console.WriteLine(item.Value.Split().First());
                }
            }
        }
    }
