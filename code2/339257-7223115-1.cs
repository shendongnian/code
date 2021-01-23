    class Program
    {
        static void Main(string[] args)
        {
            XElement main = XElement.Load(@"users.xml");
    
            var userElem = main.Descendants("User")
                .Descendants("Name")
                .Where(e => e.Value == "John Smith")
                .Select(e => e.Parent);
    
            foreach (var elem in userElem.Descendants("test"))
            {
                Console.WriteLine(elem.Descendants("Date").FirstOrDefault().Value);
                Console.WriteLine(elem.Descendants("points").FirstOrDefault().Value);
            }
            Console.ReadLine();
        }
    }
