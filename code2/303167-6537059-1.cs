    Application app = new Application();
    app.Workbooks.Open(@"C:\Sample.xlsx",
                       Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                       Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                       Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                       Type.Missing, Type.Missing);
    string data = string.Empty;
    app.ActiveWorkbook.XmlMaps[1].ExportXml(out data);
    app.Workbooks.Close();
