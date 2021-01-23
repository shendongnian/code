        using System.Xml;
        XmlNodeList nl = xd.SelectNodes("config");
        XmlNode root = list[0];
        foreach (XmlNode xnode in root.ChildNodes)
        {
            string name = xnode.Name;
            string value = xnode.InnerText;
            string nv = name + "|" + value;
            Send(nv);
        }
