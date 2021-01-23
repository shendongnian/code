        #region Read(Like)Data
        public static int ReadData<T>(List<T> data, string table, T search, string connect) where T : class, new()
        {
            return BaseRead(data, table, search, connect, "=");
        }
        public static int ReadLikeData<T>(List<T> data, string table, T search, string connect) where T : class, new()
        {
            return BaseRead(data, table, search, connect, "LIKE");
        }
        ///----------------------------------------------------------------------
        /// <summary>
        /// Reads datarows from database and adds them to list containing objects of type T.
        /// Note that the properties of T should match the fields of the database table.
        /// </summary>
        /// <param name="data">List containing objects of type T with properties matching fields in table.</param>
        /// <param name="table">Table in database.</param>
        /// <param name="search">Object of type T with (some) properties containing search constraints, 
        /// others should be null. Unused DateTime should be 1800-01-01.</param>
        /// <param name="connect">Connectionstring.</param>
        /// <returns>-1 if exception was thrown or the number of records (objects of type T) otherwise</returns>
        ///----------------------------------------------------------------------
        private static int BaseRead<T>(List<T> data, string table, T search, string connect, string comparer) where T : class, new()
        {
            // Abort if insufficient arguments
            if (data == null || table == "" || connect == "") return 0;
            // Make sure List<T> data is empty
            data.Clear();
            // Retrieve properties from object of type T 
            PropertyInfo[] propinfs = typeof(T).GetProperties();
            // -----------------------------------------
            // Create string that contains SQL-statement
            // -----------------------------------------
            string fields = ""; string wherestr = "";
            // Retrieve fields from propinf
            foreach (PropertyInfo p in propinfs)
            {
                fields += fields == "" ? p.Name : ", " + p.Name;
                dynamic propvalue = p.GetValue(search, null);
                // Solutions for properties of type DateTime
                long dateticks = 0; DateTime dt = new DateTime();
                Type type = propvalue != null ? propvalue.GetType() : null;
                if (propvalue != null && propvalue.GetType() == dt.GetType())
                {
                    dt = propvalue;
                    dateticks = dt.Ticks;
                }
                // DateTime 1800-01-01 equals null (hey, it's better than nothing...)
                if (propvalue != null && dt != DateTimeNull)
                    wherestr += wherestr == "" ? p.Name + " " + comparer + " @" + p.Name.ToLower() 
                        : " AND " + p.Name + " " + comparer + " @" + p.Name.ToLower();
            }
            // Create SQL SELECT statement with properties and search
            string sql = "SELECT " + fields + " FROM " + table;
            sql += wherestr == "" ? "" : " WHERE " + wherestr;
            // -------------------
            // Database operations
            // -------------------
            SqlCeConnection cn = new SqlCeConnection(connect);
            if (cn.State == ConnectionState.Closed) cn.Open();
            try
            {
                SqlCeCommand cmd = new SqlCeCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                // Add propertyvalues to WHERE-statement using reflection
                foreach (PropertyInfo p in propinfs)
                {
                    dynamic propvalue = p.GetValue(search, null);
                    // Except for DateTime values 1800-01-01 (defined as null)
                    if (propvalue != null && !(propvalue.GetType() is DateTime && propvalue != DateTimeNull))
                    {
                        if (comparer == "LIKE") propvalue = "%" + propvalue + "%";
                        cmd.Parameters.AddWithValue("@" + p.Name.ToLower(), propvalue);
                    }
                }
                SqlCeResultSet rs = cmd.ExecuteResultSet(ResultSetOptions.Scrollable);
                if (rs.HasRows)  // Only if database is not empty
                {
                    while (rs.Read()) // Read next row in database
                    {
                        // Instantiate single item of List data
                        var dataitem = new T();  // Object to put the field-values in
                        foreach (PropertyInfo p in propinfs)
                        {
                            // Read database fields using reflection
                            PropertyInfo singlepropinf = typeof(T).GetProperty(p.Name);
                            int ordinal = rs.GetOrdinal(p.Name);
                            dynamic result = rs.GetValue(ordinal);
                            // Conversion to null in case field is DBNull
                            if (result is DBNull)
                            {
                                if (singlepropinf.PropertyType.Equals(typeof(DateTime)))
                                {
                                    singlepropinf.SetValue(dataitem, DateTimeNull, null); // Fill data item with datetimenull
                                }
                                else
                                {
                                    singlepropinf.SetValue(dataitem, null, null); // Fill data item with null
                                }
                            }
                            else
                            {
                                singlepropinf.SetValue(dataitem, result, null); // Or fill data item with value
                            }
                        }
                        data.Add(dataitem);  // And add the record to List<T> data.
                    }
                }
                else
                {
                    //MessageBox.Show("No records matching '" + wherestr + "'!");
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
            // Return number of objects (should equal number of retrieved records)
            return data.Count();
        }
        #endregion
