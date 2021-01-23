    protected void Search_Zip_Plan_Age_Button_Click(object sender, EventArgs e)
    {       
        string _connStr = ConfigurationManager.ConnectionStrings["PriceFinderConnectionString"].ConnectionString;
    
        DataTable data = LoadZipPlanAge(_connStr, .......);
        
        Zip_Plan_Age_GridView.DataSource = data;
        Zip_Plan_Age_GridView.DataBind();
    }
    protected DataTable LoadZipPlanAge(string connString, Int64 insurAge, string zipCode, string planCode)
    {
        string storedProcName = "dbo.get_zip_plan_age";                    
        DataTable table = new DataTable();
        
        using (SqlConnection cn = new SqlConnection(connString))
        using (SqlCommand cmd = new SqlCommand(storedProcName, cn))
        {
           cmd.CommandType = CommandType.StoredProcedure;
           // create parameters
           cmd.Parameters.Add("@insur_age", SqlDbType.Int64).Value = int64Value;
           .......
           
           SqlDataAdapter dap = new SqlDataAdapter(cmd);
           dap.Fill(table);
        }
        
        return table;
    }
