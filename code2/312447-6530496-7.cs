        using System.Xml.Serialization;
        // ...
        var data = new MyClass { Field1 = "test1", Field2 = "test2" };
        var serializer = new XmlSerializer(typeof(MyClass));
        using (var stream = new StreamWriter("C:\\test.xml"))
            serializer.Serialize(stream, data);
