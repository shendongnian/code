         CollectionWrapper cw = new CollectionWrapper();
         cw.Items = new List<Foo>();
         cw.Items.Add(foo1);
         cw.Items.Add(foo2);
         cw.SomeMessage = "this is a test";
         using (TextWriter writer = new StreamWriter("C:\\foos.xml"))
         {
            XmlSerializer serializer = new XmlSerializer(typeof(CollectionWrapper));
            serializer.Serialize(writer, cw);
         }
