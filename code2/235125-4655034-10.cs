    MyClass myClass = new MyClass();
    XmlSerializer serializer = new XmlSerializer(typeof(MyClass));
    XmlWriterSettings settings = new XmlWriterSettings()
    {
        Encoding = new UnicodeEncoding(false, false)
    };
    StringBuilder xml = new StringBuilder();
    using (XmlWriter xw = XmlWriter.Create(xml, settings))
    {
        serializer.Serialize(xw, myClass);
    }
    ...
    SqlCommand cmd = new SqlCommand()
    {
        CommandText = "InsertMyClass",
        CommandType = CommandType.StoredProcedure
    };
    SqlParameter sqlParam = new SqlParameter()
    {
        ParameterName = "@x",
        SqlDbType = SqlDbType.Xml,
        Value = xml.ToString()
    };
    cmd.Parameters.Add(sqlParam);
    int count = cmd.ExecuteNonQuery();
