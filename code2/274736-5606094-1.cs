    System.IO.StreamReader sr = new System.IO.StreamReader(@"test.xml");
    System.Xml.XmlTextReader xr = new System.Xml.XmlTextReader(sr);
    System.Xml.XmlDocument save = new System.Xml.XmlDocument();
    save.Load(xr);
    string name = "Hellcode";
    XmlNodeList saveItems = save.SelectNodes(string.Format("storage/Save[@Name = '{0}']", name));
    XmlNode seconds = saveItems.Item(0).SelectSingleNode("Seconds");
    int sec = Int32.Parse(seconds.InnerText);
