    [TestMethod()]
    public void GetCodeTest()
    {
        string path = @"C:\TestArea\Tmats_09-2010.xml";
        IEnumerable<XElement> elements =
            from e in XElement.Load(path).Elements()
            select e;
        TmatsDictionary target = new TmatsDictionary();            
        XNamespace ns = "http://www.w3.org/2001/XMLSchema";
        XElement z = elements.DescendantsAndSelf(ns.GetName("element")) 
                             .First(y => y.Attribute("name")
                             .Value.Equals("ProgramName"));
        actual = target.GetCode(z);
        Assert.AreEqual("PN", actual);
    }
