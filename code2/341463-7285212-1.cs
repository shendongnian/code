    DataTable table = new DataTable();    
    System.IO.StringWriter writer = new System.IO.StringWriter();
    
    //notice that we're ignoring the schema so we get clean XML back
    //you can change the write mode as needed to get your result
    table.WriteXml(writer, XmlWriteMode.IgnoreSchema, false);
    string dataTableXml = writer.ToString();
