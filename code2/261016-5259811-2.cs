    string result;
    using (StringWriter sw = new StringWriter()) {
    dataTable.WriteXml(sw);
    result = sw.ToString();
    }
    
