        public void WriteFileToStream(FetchFileArgs args, Stream outputStream)
        {
            using (SqlConnection conn = CreateOpenConnection())
            using (SqlTransaction tran = conn.BeginTransaction(IsolationLevel.ReadCommitted))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_file";
                cmd.Transaction = tran;
                cmd.Parameters.Add("@FileId", SqlDbType.NVarChar).Value = args.Id;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string path = reader.GetString(3);
                        byte[] streamContext = reader.GetSqlBytes(4).Buffer;
                        using (var sqlStream = new SqlFileStream(path, streamContext, FileAccess.Read))
                            sqlStream.CopyTo(outputStream);
                    }
                }
                tran.Commit();
            }
        }
