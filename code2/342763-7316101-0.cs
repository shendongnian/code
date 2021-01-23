    public void CreateDataTableForExcelData(String FileName) 
    {
    OleDbConnection ExcelConnection = null;
            string filePath = Server.MapPath(Request.ApplicationPath + "/UploadedFile/");
            DataTable dtNew = new DataTable();
            string strExt = "";
            strExt = FileName.Substring(FileName.LastIndexOf("."));
            if (strExt == ".xls")
            {
                ExcelConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + hdnFileName.Value + ";Extended Properties=Excel 8.0;");
            }
            else
            {
                if (strExt == ".xlsx")
                {
                    ExcelConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + hdnFileName.Value + ";Extended Properties=Excel 12.0;");
                }
            }
            try
            {
                ExcelConnection.Open();
                DataTable dt = ExcelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                OleDbCommand ExcelCommand = new OleDbCommand(@"SELECT * FROM [" + ddlTableName.SelectedValue + @"]", ExcelConnection);
                OleDbDataAdapter ExcelAdapter = new OleDbDataAdapter(ExcelCommand);
                DataSet ExcelDataSet = new DataSet();
                ExcelAdapter.Fill(dtExcel);
                ExcelConnection.Close();
               
            }
            catch (Exception ex)
            {
    
            }
            finally
            {
            }
    }
