    string s;
    using(var reader = File.OpenText("osis.xml"))
    {
        s = reader.ReadToEnd();
    }
    s = s.Replace("xmlns=\"http://www.bibletechnologies.net/2003/OSIS/namespace\"", "");
    Stream stream = new MemoryStream(Encoding.ASCII.GetBytes(s));
    XPathDocument document = new XPathDocument("stream");
    // Rest of the code
