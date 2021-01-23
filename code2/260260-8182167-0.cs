            SqlDataReader rdr = null;
            SqlCommand cmd = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["Conn"];
                conn.Open();
                cmd = new SqlCommand("SELECT Measure_ID, Mea_Name FROM MeasureTable WHERE IsActive=1", conn);
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {
                        MeasureTypeList.Add(new Measure_Type { MeasureTypeID = Convert.ToInt32(rdr[0]), MeasureTypeName = rdr[1].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Log");
            }
            finally
            {
                cmd.Dispose();
                // close the reader
                if (rdr != null) { rdr.Close(); }
                // Close the connection
                if (conn != null) { conn.Dispose(); }
            }
            return MeasureTypeList;
