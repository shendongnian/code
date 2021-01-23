    connection.Open();
    SqlDataAdapter adapter = new SqlDataAdapter(command);
    DataTable table = new DataTable();
    adapter.Fill(table);
    if (table.Rows.Count > 0)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            XmlWriter writer = XmlTextWriter.Create(stream);
            table.WriteXml(writer);
            XmlReader reader = XmlReader.Create(stream);
            doc.Load(reader);
        }
    }
