    public class Program
    {
        public static void Main(string[] args)
        {
            var result = ExtractItem("admin");
            Console.WriteLine(result);
            Console.ReadKey();
        }
        public static string ExtractItem(string key)
        {
            var xmlString = Properties.Resource.xml; // your sample-xml-string here
            var xmlDoc = XDocument.Parse(xmlString);
            var element = xmlDoc.Descendants().FirstOrDefault(i => i.Attribute("key")?.Value == key);
            return element?.ToString();
        }
    }
