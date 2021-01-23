        string connectionString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        string selectSQL = String.Format("SELECT * FROM [{0}]", ddlTable.SelectedValue);
        
        //execute query, fill dataset
    
        GridView1.DataSource = ds;
        GridView1.DataBind();
