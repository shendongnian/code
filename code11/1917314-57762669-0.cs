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
    
            foreach (DataColumn column in excelData.Columns)
            {
                bulkInsert.ColumnMappings.Add(column.ColumnName, column.ColumnName);
            }
    
            try
            {
                bulkInsert.WriteToServer(excelData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // Debug me please. What type of exception?
                throw;
            }
    
            con.Close();
            lblerror.Text = "Your file uploaded successfull";
        }
        BindGridView();
    }
    
    private static void BindGridView()
    {
        string conString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        using (SqlConnection con = new SqlConnection(conString))
        {
            using (SqlCommand cmd = new SqlCommand("select * from tbl_data", con))
            {
                con.Open();
                gvUpload.DataSource = cmd.ExecuteReader();
                gvUpload.DataBind();
            }
        }
    }
