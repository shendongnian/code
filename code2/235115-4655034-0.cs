    XmlSerializer serializer = new XmlSerializer(typeof(MyClass));
    XmlWriterSettings settings = new XmlWriterSettings();
    settings.Encoding = new UnicodeEncoding(false, false);
    string xml = null;
    using (StringWriter sw = new StringWriter()) 
    {
        using (XmlWriter xw = XmlWriter.Create(sw, settings)) 
        {
            serializer.Serialize(xw, value);
        }
        xml = textWriter.ToString();
    }
    ...
    // Do some SQL
    SqlCommand cmd  = new SqlCommand("InsertMyClass", conn);
    cmd.CommandType = CommandType.StoredProcedure;
    
    SqlParameter sqlParam = new SqlParameter("@x", xml);
    sqlParam.Value = xml;
    cmd.Parameters.Add(sqlParam);
    int count = cmd.ExecuteNonQuery();
