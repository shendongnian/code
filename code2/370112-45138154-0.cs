    public static class DAL
    {
            public static string connectionString = ConfigurationManager.ConnectionStrings["YourWebConfigConnection"].ConnectionString;
            // function that creates a list of an object from the given data table
            public static List<T> CreateListFromTable<T>(DataTable tbl) where T : new()
            {
                // define return list
                List<T> lst = new List<T>();
                // go through each row
                foreach (DataRow r in tbl.Rows)
                {
                    // add to the list
                    lst.Add(CreateItemFromRow<T>(r));
                }
                // return the list
                return lst;
            }
            // function that creates an object from the given data row
            public static T CreateItemFromRow<T>(DataRow row) where T : new()
            {
                // create a new object
                T item = new T();
                // set the item
                SetItemFromRow(item, row);
                // return 
                return item;
            }
            public static void SetItemFromRow<T>(T item, DataRow row) where T : new()
            {
                // go through each column
                foreach (DataColumn c in row.Table.Columns)
                {
                    // find the property for the column
                    PropertyInfo p = item.GetType().GetProperty(c.ColumnName);
                    // if exists, set the value
                    if (p != null && row[c] != DBNull.Value)
                    {
                        p.SetValue(item, row[c], null);
                    }
                }
            }
            
            //call stored procedure to get data.
            public static DataSet GetRecordWithExtendedTimeOut(string SPName, params SqlParameter[] SqlPrms)
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                SqlConnection con = new SqlConnection(connectionString);
                try
                {
                    cmd = new SqlCommand(SPName, con);
                    cmd.Parameters.AddRange(SqlPrms);
                    cmd.CommandTimeout = 240;
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                }
                catch (Exception ex)
                {
                   return ex;
                }
                return ds;
            }
    }
