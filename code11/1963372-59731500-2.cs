    protected void Button_update(object sender, ImageClickEventArgs e)
    {
    
        using (SqlConnection sqlCon = new SqlConnection(@"Data Source= DESKTOP-U9437PU; initial Catalog = Mydb; Integrated Security =True;"))
        {
            sqlCon.Open();
    
           string sql = "update requests_table set stat_id = '2' where req_id ='" 5 "'";
           SqlCommand cmd1 = new SqlCommand(sql, sqlCon);
           cmd1.ExecuteNonQuery();
           cmd1.Dispose();
           sqlCon.Close();
        }
        GridView1.DataBind(); 
    	UpdatePanel1.Update();
    
    }
