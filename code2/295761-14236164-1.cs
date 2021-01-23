    {
           //getting name of the file
     string fileName = Path.GetFileName(Upload_File.PostedFile.FileName);  
    //getting extension of the file (for checking purpose - which type .xls or .xlsx)
    string fileExtension = Path.GetExtension(Upload_File.PostedFile.FileName);  
    string fileLocation = Server.MapPath("" + fileName);    //exact location of the excel files
    Upload_File.SaveAs(fileLocation);
     //Check whether file extension is xls or xslx
        
     if (fileExtension == ".xls")
     {
    connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
         }
     else if (fileExtension == ".xlsx")
        {
       connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
          }   
         //Create OleDB Connection and OleDb Command
        
                        OleDbConnection con = new OleDbConnection(connectionString);
                        OleDbCommand cmd = new OleDbCommand();
                        //cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Connection = con;
                        OleDbDataAdapter dAdapter = new OleDbDataAdapter(cmd);
                        DataTable dtExcelRecords = new DataTable();
                        con.Open();
    DataTable dtExcelSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    string getExcelSheetName = dtExcelSheetName.Rows[0]["Table_Name"].ToString();
                        cmd.CommandText = "SELECT * FROM [" + getExcelSheetName + "]";
                        dAdapter.SelectCommand = cmd;
                        dAdapter.Fill(dtExcelRecords);
                        con.Close();
                        Gridview_Name.DataSource = dtExcelRecords;
                        GridView_Name.DataBind();
                    }
                    else
                    {
                        Response.Write("Please Select a File to extract data ");
                    }
                }
