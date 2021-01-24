    static void Main(string[] args)
    {
        string path = string.Concat(Server.MapPath("~/UploadFile/" + FileUpload1.FileName));
        FileUpload1.SaveAs(path);
        string excelCS = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
    
        using (OleDbConnection con = new OleDbConnection(excelCS))
        {
            DataTable excelData = new DataTable();
    
            using (OleDbCommand excelSource = new OleDbCommand("select * from [Sheet1$]", con))
            {
                con.Open();
                excelData.Load(excelSource.ExecuteReader());
            }
    
            // SQL Server Connection String
            string CS = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);
            bulkInsert.DestinationTableName = "tbl_data";   
            bulkInsert.ColumnMappings.Add(0,0);
            bulkInsert.ColumnMappings.Add(1,1);     
    
            try
            {
                bulkInsert.WriteToServer(excelData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
                    
            con.Close();
            lblerror.Text = "Your file uploaded successfully";
        }
        BindGridView();
    }
    
    private static void BindGridView()
    {
        string conString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        using (SqlConnection con = new SqlConnection(conString))
        {
            using (SqlCommand cmd = new SqlCommand("select ID, Mail_ID from tbl_data", con))
            {
                con.Open();
                var sqlReader = cmd.ExecuteReader();
                Console.WriteLine("START: Sql Columns");
                foreach (var sqlColumnName in Enumerable.Range(0, sqlReader.FieldCount).Select(sqlReader.GetName))
                {
                    Console.WriteLine(sqlColumnName);
                }
                Console.WriteLine("END: Sql Columns");
                gvUpload.DataSource = sqlReader;
                gvUpload.DataBind();
            }
        }
    }
