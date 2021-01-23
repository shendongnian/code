            try
            {
                //ConnectionString = String.Format("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={2})));User Id={3};Password={4};", "ServerAddress", "PortAddress", "DatabaseName", "Username", "Password");
                ConnectionString = String.Format("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={2})));User Id={3};Password={4};", "10.87.5.40", "1521", "FOCORA1", "SYSADM", "SYSADM");
                OracleConnection oraConn = new OracleConnection(ConnectionString);
                oraConn.Open();
                OracleCommand oraCMD = new OracleCommand();
                oraCMD.Connection = oraConn;
                
                var oracleBulkCopy = new OracleBulkCopy(oraConn)
                {
                    DestinationTableName = "test_bulk",
                    BulkCopyOptions = OracleBulkCopyOptions.UseInternalTransaction
                };
                    DataTable oDataTable = GetDataTableFromObjects<test_bulk>(lsttest_bulk);
                    oracleBulkCopy.WriteToServer(oDataTable);
                    oracleBulkCopy.Dispose();
            }
            catch(Exception ex)
            {
                Console.WriteLine("failed to write:\t{0}", ex.Message);
            }
        }
        public static DataTable GetDataTableFromObjects<TDataClass>(List<TDataClass> dataList)
        where TDataClass : class
        {
            Type t = typeof(TDataClass);
            DataTable dt = new DataTable(t.Name);
            foreach (PropertyInfo pi in t.GetProperties())
            {
                dt.Columns.Add(new DataColumn(pi.Name));
            }
            if (dataList != null)
            {
                foreach (TDataClass item in dataList)
                {
                    DataRow dr = dt.NewRow();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        dr[dc.ColumnName] =
                          item.GetType().GetProperty(dc.ColumnName).GetValue(item, null);
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
