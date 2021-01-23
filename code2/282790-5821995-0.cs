        // My guess of how wrong code looks like! Not a solution!!!!
        StreamReader r = new StreamReader(path, System.Text.Encoding.Unicode);
        string xml = r.ReadToEnd();
        XmlDocument d = new XmlDocument();
        d.LoadXml(xml);
   
