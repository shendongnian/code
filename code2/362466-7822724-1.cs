    private static void Main()
    {
        Foo foo = "abc";
    
        var ns = new XmlSerializerNamespaces();
        ns.Add(string.Empty, string.Empty);
    
        var serialzier = new XmlSerializer(typeof(Foo));
    
        using (var writer = new StringWriter())
        {
            serialzier.Serialize(writer, foo, ns);
    
            Console.WriteLine(writer.ToString());
        }
    }
