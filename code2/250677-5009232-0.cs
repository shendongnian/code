    IEnumerable<KeyValuePair<String, Object>> data = LoadData(); // however you populate your collection
    var dataAsList = data.ToList(); 
    XmlSerializer serializer = new XmlSerializer(dataAsList.GetType());
    StringWriter sw = new StringWriter();
    serializer.Serialize(sw,dataAsList );
    var xml = sw.ToString();
    ...
    ...
