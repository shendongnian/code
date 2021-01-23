    private void LoadFromDictionary()
        {
                Encoding enc = Encoding.GetEncoding(1250);
                string strConn = @"Data Source=C:\Temp2\dictionary.s3db";
                SqliteConnection conn = new SqliteConnection(strConn);
                conn.Open();
                string insSQL = "insert or ignore into Words values('?')";
                DbCommand oCommand = conn.CreateCommand();
                oCommand.Connection = conn;
                oCommand.CommandText = insSQL;
                DbParameter oParameter = oCommand.CreateParameter();
                oParameter.DbType = DbType.String;
                oParameter.Size = 100;
                oCommand.Parameters.Add(oParameter);
                DbTransaction oTransaction = conn.BeginTransaction();
                using (StreamReader r = new StreamReader("c:\\Temp2\\dictionary.txt", enc))
                {
                    string line = "";
                    while ((line = r.ReadLine()) != null)
                    {
                        line = line.Trim();
                        if (!string.IsNullOrEmpty(line)) {
                          oParameter.Value = line;
                          oCommand.ExecuteNonQuery();
                        }
                    }
                }
                oTransaction.Commit();
                conn.Close();
                MessageBox.Show("Finally :P", "Info");
            }
