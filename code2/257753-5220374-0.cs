        #region ReadData
        ///----------------------------------------------------------------------
        /// <summary>
        /// Reads datarows from database and adds them to list.
        /// </summary>
        /// <param name="data">List containing objects with properties matching fields in table.</param>
        /// <param name="table">Table in database.</param>
        /// <param name="search">Substring of SQL-statement that follows 'WHERE' (optional).</param>
        /// <param name="connect">Connectionstring.</param>
        /// <returns>-1 if exception was thrown or the result of ExecuteNonQuery otherwise</returns>
        ///----------------------------------------------------------------------
        public static int ReadData<T>(List<T> data, string table, string search, string connect) where T : class, new()
        {
            // abort if insufficient arguments
            if (data == null || table == "" || connect == "") return 0;
            
            // retrieve properties from Data 
            PropertyInfo[] propinfs = typeof(T).GetProperties();
            // create string with SQL-statement
            string fields = "";
            // retrieve fields from propinf
            foreach (PropertyInfo p in propinfs)
            {
                fields += fields == "" ? p.Name : ", " + p.Name;
            }
            // create SQL SELECT statement with properties and search
            string sql = "SELECT " + fields + " FROM " + table;
            sql += search == "" ? "" : " WHERE " + search;
            //messg("*" + sql + "*");
            // Instantiate and open database
            SqlCeConnection cn = new SqlCeConnection(connect);
            if (cn.State == ConnectionState.Closed)
            cn.Open();
            data.Clear();   // just in case
            try
            {
                SqlCeCommand cmd = new SqlCeCommand(sql, cn); 
                cmd.CommandType = CommandType.Text;
                SqlCeResultSet rs = cmd.ExecuteResultSet(ResultSetOptions.Scrollable);
                if (rs.HasRows)  // Only if database is not empty
                {
                    while (rs.Read()) // read database
                    {
                        // instantiate single item of List<data>
                        var dataitem = new T();
                        int ordinal = 0;
                        foreach (PropertyInfo p in propinfs)
                        {
                            // read database and
                            PropertyInfo singlepropinf = typeof(T).GetProperty(p.Name);
                            ordinal = rs.GetOrdinal(p.Name);
                            singlepropinf.SetValue(dataitem, rs.GetValue(ordinal), null); // fill data item
                        }
                        data.Add(dataitem);  // and add it to data.
                    }
                }
                else
                {
                    //MessageBox.Show("No records matching '" + search + "'!");
                    return 0;
                }
            }
            catch (SqlCeException sqlexception)
            {
                MessageBox.Show(sqlexception.Message, "SQL-error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                cn.Close();
            }
            return data.Count();
        }
        #endregion
