    public void bindGridView()
    {
        //declare the connection string to use
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //create sql connection
        SqlConnection mySQLconnection = new SqlConnection(connectionString);
        //open connection
        mySQLconnection.Open();
            //define command using text string
            SqlCommand mySqlCommand = new SqlCommand(sqlTester, mySQLconnection);
            SqlDataAdapter mySqlAdapter = new SqlDataAdapter(mySqlCommand);
            //create dataset to fill gridview with
            DataSet myDataSet = new DataSet();
            mySqlAdapter.Fill(myDataSet);
            //fill gridview
            GridView1.DataSource = myDataSet;
            GridView1.DataBind();
            viewstate.add("myDataSet",myDataSet);
        //close the sql connection
        mySQLconnection.Close();
    }
