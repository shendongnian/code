    class Program
    {
        static void Main(string[] args)
        {
            var xRoot = new XmlRootAttribute { ElementName = "container", IsNullable = true };
            var serializer = new XmlSerializer(typeof(Folder), xRoot);
            // TODO: replace "./input.xml" by a non static file path
            using (var reader = new StreamReader("./input.xml"))
            {
                var result = (Folder)serializer.Deserialize(reader);
                Console.WriteLine(result);
            }
        }
    }
