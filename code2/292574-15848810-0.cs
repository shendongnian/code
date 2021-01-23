        try
        {
            if ((txtFilePath.HasFile))
            {
                OleDbConnection conn = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter da = new OleDbDataAdapter();
                DataSet ds = new DataSet();
                string query = null;
                string connString = "";
                string strFileName = DateTime.Now.ToString("ddMMyyyy_HHmmss");
                string strFileType = System.IO.Path.GetExtension(txtFilePath.FileName).ToString().ToLower();
                if (strFileType == ".xls" || strFileType == ".xlsx")
                {
                    txtFilePath.SaveAs(Server.MapPath("~/UploadedExcel/" + strFileName + strFileType));
                }
                string strNewPath = Server.MapPath("~/UploadedExcel/" + strFileName + strFileType);
                if (strFileType.Trim() == ".xls")
                {
                    connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strNewPath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                }
                else if (strFileType.Trim() == ".xlsx")
                {
                    connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strNewPath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                }
                conn = new OleDbConnection(connString);
                if (conn.State == ConnectionState.Closed) conn.Open();
                string SpreadSheetName = "";
                DataTable ExcelSheets = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                SpreadSheetName = ExcelSheets.Rows[0]["TABLE_NAME"].ToString();
                query = "SELECT * FROM [" + SpreadSheetName + "]";
                cmd = new OleDbCommand(query, conn);
                da = new OleDbDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "tab1");
             }
          }
     }
