    public bool ImportDataToSQLiteDatabase(string Proc, string SQLiteDatabase, params object[] obj)
        {
            DataTable result = null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                result = new DataTable();
                using (conn = new SqlConnection(ConStr))
                {
                    using (cmd = CreateCommand(Proc, CommandType.StoredProcedure, obj))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        result.Load(cmd.ExecuteReader());
                    }
                }
                using (SQLiteConnection con = new SQLiteConnection(string.Format("Data Source={0};Version=3;New=False;Compress=True;Max Pool Size=100;", SQLiteDatabase)))
                {
                    con.Open();
                    using (SQLiteTransaction transaction = con.BeginTransaction())
                    {
                        foreach (DataRow row in result.Rows)
                        {
                            using (SQLiteCommand sqlitecommand = new SQLiteCommand("insert into table(fh,ch,mt,pn) values ('" + Convert.ToString(row[0]) + "','" + Convert.ToString(row[1]) + "','"
                                                                                                                                  + Convert.ToString(row[2]) + "','" + Convert.ToString(row[3]) + "')", con))
                            {
                                sqlitecommand.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                        new General().WriteApplicationLog("Data successfully imported.");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                result = null;
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
