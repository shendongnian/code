    [Test]
    public void ParsesObjectFromXml()
    {
         string xmlInput = " ... ";
         MyObjectXmlParser parser = new MyObjectXmlParser();
         MyObject expected = new MyObject() {Title = "obj", Name="objName"};
         AssertMyObjectsAreEqual(expected, parser.Parse(xmlInput));
    }
    private bool AssertMyObjectsAreEqual(MyObject expected, MyObject actual)
    {
         Assert.AreEqual(expected.Title, actual.Title);
         Assert.AreEqual(expected.Name, actual.Name);
    }
