    public int ObjectContentI(string XmlPath)
    {
        int result;
        using(XmlNodeReader xnr = new XmlNodeReader(this.xmlr.SelectSingleNode(XmlPath))){
            while(xnr.Read()){
                result = xnr.ReadElementContentAsInt();
            }
        }
        return result;
    }
