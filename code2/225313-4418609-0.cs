    XDocument doc = XDocument.Load("test.xml");
    // You could use an array if you really wanted, of course.
    List<MyClass> list = doc.Root
                            .Elements("Item")
                            .Select(x => new MyClass {
                                Property1 = (string) x.Attribute("Property1"),
                                Property2 = (string) x.Attribute("Property2"),
                             })
                            .ToList();
