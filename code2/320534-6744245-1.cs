        /// <summary>
        /// Import Function For Xlsx  File
        /// </summary>
        /// <param name="s">File Name</param>
        /// <returns> Datatable </returns>
        private DataTable Import4Xlsx(string s)
        {
            string conn = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                          "Data Source=" + s + ";" +
                          "Extended Properties='Excel 12.0 Xml;Allow Zero DateTime=True;" +
                          "HDR=YES;IMEX=1\"'";
            string[] sheetname = GetExcelSheetNames(conn);
            try
            {
                var objConn = new OleDbConnection(conn);
                objConn.Open();
                var ds = new DataSet();
                var da = new OleDbDataAdapter("SELECT * FROM [" + sheetname[0] + "]", conn);
                da.Fill(ds);
                objConn.Close();
                return ds.Tables[0];//resultant data
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message + ex.Source);
                return null;
            }
        }
        /// <summary>
        /// Get Excel Files Sheet Name
        /// </summary>
        /// <param name="con">Connection String</param>
        private String[] GetExcelSheetNames(string con)
        {
            OleDbConnection objConn = null;
            DataTable dt = null;
            try
            {
                objConn = new OleDbConnection(con);
                objConn.Open();
                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null) return null;
                var excelSheets = new String[dt.Rows.Count];
                int i = 0;
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[i] = row["TABLE_NAME"].ToString();
                    i++;
                }
                return excelSheets;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message + ex.Source);
                return null;
            }
            finally
            {
                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }
