    var xDocument = XDocument.Load("EL-Zednadebi.xml");
    // XML elements are in the "ss" namespace.
    XNamespace ss = "urn:schemas-microsoft-com:office:spreadsheet";
    var rows = xDocument.Root.Element(ss + "Worksheet")
      .Element(ss + "Table").Elements(ss + "Row");
    // Row 12.
    var row = rows.ElementAt(11);
    var cells = row.Elements(ss + "Cell");
    // Column U.
    var cell = cells.ElementAt(20);
    var data = cell.Element(ss + "Data");
    // Replace the text in the cell.
    data.Value = "Martin Liversage";
    xDocument.Save("EL-Zednadebi-2.xml");
