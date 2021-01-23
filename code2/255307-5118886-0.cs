    public static string SerializeToString(object o)
    {
        string serialized = "";
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //Serialize to memory stream
        System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(o.GetType());
        System.IO.TextWriter w = new System.IO.StringWriter(sb);
        ser.Serialize(w, o);
        w.Close();
        //Read to string
        serialized = sb.ToString();
        return serialized;
    }
