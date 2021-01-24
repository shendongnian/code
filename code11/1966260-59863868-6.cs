    class Program
    {
        static void Main(string[] args)
        {
            var rootAttribute = new XmlRootAttribute { ElementName = "container", IsNullable = true };
            var serializer = new XmlSerializer(typeof(Container), rootAttribute);
            using (var reader = new StreamReader("./input.xml"))
            {
                var result = (Container)serializer.Deserialize(reader);
                Console.WriteLine(result);
            }
        }
    }
