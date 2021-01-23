    // serialize into a string
    StringBuilder sb = new StringBuilder();
    StringWriter sw = new StringWriter(sb);
    // create a serializer for my specific type
    XmlSerializer ser = new XmlSerializer(typeof(Dictionary<int, List<int[,]>>));
    // perform serialization
    ser.Serialize(sw, myObj);
    // retrieve the final serialized result as a string I can work with
    string serialized = sb.ToString();
    // do something with serialized object
