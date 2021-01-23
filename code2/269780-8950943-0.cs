    // Assuming obj is an instance of an object
    XmlSerializer ser = new XmlSerializer(obj.GetType());
    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    System.IO.StringWriter writer = new System.IO.StringWriter(sb);
    ser.Serialize(writer, obj);
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(sb.ToString());
