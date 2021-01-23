    XmlDocument FromHtml(TextReader reader) {
    
        // setup SgmlReader
        Sgml.SgmlReader sgmlReader = new Sgml.SgmlReader();
        sgmlReader.DocType = "HTML";
        sgmlReader.WhitespaceHandling = WhitespaceHandling.All;
        sgmlReader.CaseFolding = Sgml.CaseFolding.ToLower;
        sgmlReader.InputStream = reader;
    
        // create document
        XmlDocument doc = new XmlDocument();
        doc.PreserveWhitespace = true;
        doc.XmlResolver = null;
        doc.Load(sgmlReader);
        return doc;
    }
