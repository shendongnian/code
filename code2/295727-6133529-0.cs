    var xRoot = new System.Xml.Serialization.XmlRootAttribute();
    xRoot.ElementName = "MySpecialResponse";
    xRoot.IsNullable = true;
    xRoot.Namespace = rootResponseNamespace;
    var serialiser = new System.Xml.Serialization.XmlSerializer(typeof(MySpecialResponse), xRoot);
