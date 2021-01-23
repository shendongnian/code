    class Program
    {
        static void Main()
        {
            var doc = new HtmlDocument();
            doc.Load("test.html");
            var anchor = doc.DocumentNode.SelectSingleNode("//a");
            Console.WriteLine(anchor.Attributes["href"].Value);
            Console.WriteLine(anchor.InnerText);
        }
    }
