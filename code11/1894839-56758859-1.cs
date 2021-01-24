	using (FileStream retryFile = System.IO.File.Create(filePath))
	using (var xmlWriter = XmlWriter.Create(retryFile))
	{
		xmlWriter.WriteStartElement("Records");
		var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
		var ser = new XmlSerializer(typeof(Record));
		
        /* Your loop goes here. */ 
		ser.Serialize(xmlWriter, new Record { Name = "foo" }, emptyNamespaces);
		ser.Serialize(xmlWriter, new Record { Name = "bar" }, emptyNamespaces);
		ser.Serialize(xmlWriter, new Record { Name = "baz" }, emptyNamespaces);
		xmlWriter.WriteEndElement();
	}
    public class Record 
    { 
        public string Name {get; set; } 
    }
