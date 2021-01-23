    XmlDoc xmlData = new XmlDoc();
    XmlParser parser = new XmlParser();
    parser.MainParse(xmlData, fileIn)
    ...
    public void MainParse(XmlDoc xmlData, FileStream fileIn)
    {
        ...
        ParseElement(xmlData, ref byteIn, fileIn);
        ...
    }
    public void ParseElement(XmlDoc xmlData, ref int byteIn,FileStream fileIn)
    {
        ...
    }
