    private void DisplayData()
    {
        using(SqlConnection objCon = new SqlConnection())
        using(SqlCommand objCmd = new SqlCommand())
        {
             objCon.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            objCon.Open();
        
            objCmd.Connection = objCon;
            objCmd.CommandText = "Select * From Community Where Category = @cat Order By Num Desc";
            objCmd.Parameters.Add("@cat", SqlDbType.NVarChar).Value = Request["Category"].ToString();
            
            if (Request["Category"] == "All")
            {
               objCmd.CommandText = "Select * From Community Where Category != @cat Order By Num";
               objCmd.Parameters[0].Value = "Blog"    
            }
            SqlDataAdapter objDa = new SqlDataAdapter();
            objDa.SelectCommand = objCmd;
            DataSet objDs = new DataSet();
            objDa.Fill(objDs, "Community");
            this.ctlList.DataSource = objDs.Tables[0];
            this.ctlList.DataBind();
    }
