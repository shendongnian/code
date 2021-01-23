    DataSet dataSet = new DataSet();
    DataTable dataTable = new DataTable("table1");
    dataTable.Columns.Add("col1", typeof(string));
    dataSet.Tables.Add(dataTable);
    string xmlData = "<XmlDS><table1><col1>Value1</col1></table1><table1><col1>Value2</col1></table1></XmlDS>";
    System.IO.StringReader xmlSR = new System.IO.StringReader(xmlData);
    dataSet.ReadXml(xmlSR, XmlReadMode.IgnoreSchema);
