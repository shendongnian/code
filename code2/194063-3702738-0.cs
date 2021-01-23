    XElement myTable = xdoc.Descendants("table").FirstOrDefault(xelem => xelem.Attribute("class").Value == "inner");
    IEnumerable<IEnumerable<XElement>> myRows = myTable.Elements().Select(xelem => xelem.Elements());
    foreach(IEnumerable<XElement> tableRow in myRows)
    {
        foreach(XElement rowCell in tableRow)
        {
            // tada..
        }
    }
