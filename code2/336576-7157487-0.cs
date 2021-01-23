    XDocument xDoc = XDocument.Load(System.Web.HttpContext.Current.Server.MapPath("XmlFile.xml"));
    
    var names = from x in xDoc.Descendants("students")
                select x.Element("name");
    foreach (XElement studentName in names)
    {
        LblDisplay.Text += studentName.Value + " ";
    }
    LblDisplay.Text += "<br />";
