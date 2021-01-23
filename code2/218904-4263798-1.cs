    public static DataSet GetPrimaryKeyTables()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection sConnection = new SqlConnection(connectionString);
            string selectPrimaryKeys;
            //Opens the connection      
            sConnection.Open();
            selectPrimaryKeys = @"SELECT [TABLE_NAME]
            FROM      [INFORMATION_SCHEMA.TABLE_CONSTRAINTS]
            WHERE     [CONSTRAINT_TYPE = 'PRIMARY KEY']
            ORDER BY  [TABLE_NAME]";
            SqlCommand sCommand = new SqlCommand(selectPrimaryKeys, sConnection);
            try
            {
                DataSet dtPrimaryKeysTables = new DataSet("INFORMATION_SCHEMA.TABLE_CONSTRAINTS");
                SqlDataAdapter da = new SqlDataAdapter(selectPrimaryKeys, sConnection);
                da.TableMappings.Add("Table", "INFORMATION_SCHEMA.TABLE_CONSTRAINTS");
                da.Fill(dtPrimaryKeysTables);
                DataViewManager dsva = dtPrimaryKeysTables.DefaultViewManager;
                return dtPrimaryKeysTables;
            }
            catch (Exception ex)
            {
                //All the exceptions are handled and written in the EventLog.
                EventLog log = new EventLog("Application");
                log.Source = "MFDBAnalyser";
                log.WriteEntry(ex.Message);
                return null;
            }
            finally
            {
                //To close the connection
                if (sConnection != null)
                {
                    sConnection.Close();
                }
            }
        }
