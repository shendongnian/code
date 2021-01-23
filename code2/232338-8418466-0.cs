    public static Version GetPublishedVersion()
    {
        XmlDocument xmlDoc = new XmlDocument();
        Assembly asmCurrent = System.Reflection.Assembly.GetExecutingAssembly();
        string executePath = new Uri(asmCurrent.GetName().CodeBase).LocalPath;
        xmlDoc.Load(executePath + ".manifest");
        string retval = string.Empty;
        if (xmlDoc.HasChildNodes)
        {
            retval = xmlDoc.ChildNodes[1].ChildNodes[0].Attributes.GetNamedItem("version").Value.ToString();
        }
        return new Version(retval);
    }
    
