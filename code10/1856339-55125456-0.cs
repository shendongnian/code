    XmlDocument doc = new XmlDocument();
    doc.Load(@"InternList.xml");
    
    // Loop over child nodes of <ArrayOfInternship>...
    foreach (XmlNode node in doc.DocumentElement)
    {
        // Loop over the child nodes of the <Internship> nodes
        foreach (XmlNode child in node.ChildNodes)
        {
            if (child.Name.Equals("Title", StringComparison.OrdinalIgnoreCase))
            {
                lstBxListIntern.Items.Add(child.InnerText);
            }
        }
    }
