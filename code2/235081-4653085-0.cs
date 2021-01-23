    public void GenerateInvoiceXML<TTable>(string filePath) {
        var dataForXML = app.db.Table<TTable>().ToList();
    
        XmlSerializer serializer = new XmlSerializer( typeof(List<TTable>) );
        TextWriter writer = new StreamWriter(filePath);
    
        serializer.Serialize(writer,dataForXML);
        writer.Close();     
    }
