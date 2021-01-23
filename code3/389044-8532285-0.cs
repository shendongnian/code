    String connStr = "connection string";
    // add here extension that depends on your file type
    string fileName = Path.GetTempFileName() + ".doc";
    using (SqlConnection conn = new SqlConnection(connStr))
    {
        conn.Open();
        using (SqlCommand cmd = conn.CreateCommand())
        {
            // you have to distinguish here which document, I assume that there is an `id` column
            cmd.CommandText = "select document from documents where id = @id";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1;
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    int size = 1024 * 1024;
                    byte[] buffer = new byte[size];
                    int readBytes = 0;
                    int index = 0;
                    using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        while ((readBytes = (int)dr.GetBytes(0, index, buffer, 0, size)) > 0)
                        {
                            fs.Write(buffer, 0, readBytes);
                            index += readBytes;
                        }
                    }
                }
            }
        }
    }
    // open your file, the proper application will be executed because of proper file extension
    Process prc = new Process();
    prc.StartInfo.FileName = fileName;
    prc.Start();
