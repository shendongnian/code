        public static DataTable SPExecuteTable(string commandText = "", List<object> paras = null)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            Exception ex = null;
                using (MySqlCommand com = MySQlComnd(commandText, paras))
                {
                    try
                    {
                        com.Connection.Open();
                        using (MySqlDataAdapter oda = new MySqlDataAdapter())
                        {
                            oda.SelectCommand = com;
                            oda.Fill(ds);
                            dt = ds.Tables[0];
                        }
                    }
                    catch (Exception e)
                    {
                        ex = e;
                    }
                    finally
                    {
                        com.Connection.Close();
                        com.Connection.Dispose();
                    }
                }
            
            if (ex != null)
                throw ex;
            return dt;
        }
