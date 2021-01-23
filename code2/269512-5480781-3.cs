    static void Main(string[] args)
    {
        var schema = new XmlSchema();
        // <xs:element name="myElement" type="xs:string"/>
        var myElement = new XmlSchemaElement();
        schema.Items.Add(myElement);
        elementCat.Name = "myElement";
        elementCat.SchemaTypeName = 
            new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
        // writing it out to any stream
        var nsmgr = new XmlNamespaceManager(new NameTable());
        nsmgr.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
        schema.Write(Console.Out, nsmgr);
        Console.ReadLine();
    }
