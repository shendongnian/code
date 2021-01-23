    var myAss = Assembly.GetExecutingAssembly();
    using (var s = myAss.GetManifestResourceStream(string.Format("{0}.foo.xml", 
                                                   myAss.GetName().Name)))
    {
        var doc = new XmlDocument();
        doc.Load(s);
    }
