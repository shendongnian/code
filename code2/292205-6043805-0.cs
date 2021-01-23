        SqlConnection con = new SqlConnection("");//put connection string here
        SqlCommand objCommand = new SqlCommand("SELECT FirstName, LAstName from MyTable where FirstName = '" + "ABC" + "'", con);//let MyTable be a database table
    con.Open();
        sqlDataReader dr = objCommandExecuteReader();
    myGridView.DataSource = dr;//let myGridView be your GridView name
    myGridView.DataBind();
