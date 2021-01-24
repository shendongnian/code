        public static bool GetConnection()
        {
            String connectionString = "Data Source=Test;User ID=Test;Password=Test;";
            try
            {
                Connection = new OracleConnection(connectionString);
                //Connection.Open();
                return true;
            }
            catch (OracleException ww)
            {
                MessageBox.Show(ww.ToString());
                return false;
            }
        }
        public static int ExecuteStatement(string query)
        {
            if (fncOpenConnection(false))
            {
                try
                {
                    OracleCommand cmd = new OracleCommand(query, Connection);
                    int rowCount = cmd.ExecuteNonQuery();
                    return rowCount;
                }
                catch (Exception ex)
                {
                    GlobalApp.ErrorMsg = ex.ToString();
                    return -1;
                }
            }
            else return -1;
        }
        public static int ExecuteStatement_TXN(string query)
        {
            if (fncOpenConnection(false))
            {
                OracleTransaction txn;
                txn = Connection.BeginTransaction();
                try
                {
                    OracleCommand cmd = new OracleCommand(query, Connection);
                    int rowCount = cmd.ExecuteNonQuery();
                    txn.Commit();
                    return rowCount;
                }
                catch (Exception er)
                {
                    GlobalApp.ErrorMsg = er.ToString();
                    txn.Rollback();
                    return -1;
                }
            }
            else return -1;
        }
    
        
    
        public static OracleDataReader GetReader(string query)
        {
            fncOpenConnection(false);
            OracleDataReader dr = null;
            try
            {
                OracleCommand cmd = new OracleCommand(query, Connection);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return dr;
            }
        }
  
        public static DataTable GetTable(string query, int[] primaryKeyCol = null)
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                OracleDataAdapter oadp = new OracleDataAdapter(query, Connection);
               
                oadp.Fill(dt);
           
                if (primaryKeyCol != null)
                {
                    DataColumn[] keyColumns = new DataColumn[primaryKeyCol.Count()];
                    int iCount = 0;
                    foreach (int x in primaryKeyCol)
                    {
                        keyColumns[iCount] = dt.Columns[x];
                        iCount = iCount + 1;
                    }
                    dt.PrimaryKey = keyColumns;
                }
                return dt;
            }
            catch (Exception)
            {
                return dt;
            }
        }
