         FooList content = new FooList();
         content.Add(foo1);
         content.Add(foo2);
         CollectionWrapper cw = new CollectionWrapper();
         cw.Items = content;
         cw.SomeMessage = "this is a test";
         using (TextWriter writer = new StreamWriter("C:\\foos.xml"))
         {
            XmlSerializer serializer = new XmlSerializer(typeof(CollectionWrapper));
            serializer.Serialize(writer, cw);
         }
