    var reader = Excel.ExcelReaderFactory.CreateOpenXmlReader(uploadFile.InputStream);
    do
    {
        while (reader.Read())
        {
            System.Diagnostics.Debug.WriteLine(reader.FieldCount );
            for (int i = 0; i < reader.FieldCount; i++)
            {
                System.Diagnostics.Debug.Write(reader[i] + "*");
            }
            System.Diagnostics.Debug.WriteLine("\n~\n");
        }
    }while(reader.NextResult());
