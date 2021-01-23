    public string CompileResults(XElement e)
    {
        string retVal = String.Format("{0}:{1} ", e.Name, e.Value);
        foreach (XAttribute xa in e.Attributes())
            retVal += String.Format("{0}:{1} ", xa.Name, xa.Value);
        foreach (XElement xe in e.Elements())
            retVal += CompileResults(xe); ;
        return retVal;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        string fileName = Application.StartupPath + "\\XMLFile1.xml";
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(fileName);
        string results = CompileResults(xmlDoc.FirstChild);
    }
