        string filename = UploadFile(fuCompanies);
        OleDbConnection Econ = new OleDbConnection(string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", Server.MapPath("~/files/excels/" + filename)));
        DataSet ds = new DataSet();
        try
        {
            Econ.Open();
            DataTable activityDataTable = Econ.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            OleDbCommand Ecom = new OleDbCommand();
            Ecom.Connection = Econ;
            Ecom.CommandText = string.Format("Select * FROM [{0}]", activityDataTable.Rows[0]["TABLE_NAME"]);
            OleDbDataAdapter oda = new OleDbDataAdapter(Ecom.CommandText, Econ);
            oda.Fill(ds);
        }
        catch (Exception ex)
        {
            //Exception
        }
        finally
        {
            Econ.Close();
        }
        foreach(DataColumn dc in ds.Tables[0].Columns){
            // take columns here and create a dynamic class
        }
        
