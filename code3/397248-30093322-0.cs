    public static string TableToString(this DataTable data)
        {
            string xmlString = string.Empty;
            using (TextWriter writer = new StringWriter())
            {
                data.WriteXml(writer,XmlWriteMode.WriteSchema );
                xmlString = writer.ToString();
            }
            return xmlString;
        }
