    XDocument doc = XDocument.Load(MapPath("~/filename.xml"));
    var result = from n in doc.Descendants("Domain")
                 select new
                    {
                       Domain = n.HasAttributes ? n.Attribute("name").Value : "",
                       Indicator=n.Element("Indicator").Value,
                       AttainmentDate = n.Element("AttainmentDate").Value,
                       Remark=n.Element("AttainmentDate").Value 
                   };
    
    ISPChecklist.DataSource = result.ToList();
    ISPChecklist.DataBind();
