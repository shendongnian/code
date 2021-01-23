    Best Solution :- There is only problem with your "CommandText" value. Let it be SP or normal Sql Query.
    
    Check-1: The parameter value which you are passing in your Sql Query is not changing and going same again and again in your ExecuteReader.
    
    Check-2: Sql Query string is wrongly formed.
    Check-3: Please create simplest code as follows.
    
    string ID = "C8CA7EE2";
    string myQuery = "select * from ContactBase where contactid=" + "'" + ID + "'";
    string connectionString = ConfigurationManager.ConnectionStrings["CRM_SQL_CONN_UAT"].ToString(); 
    SqlConnection con = new SqlConnection(connectionString);
    con.Open();
    SqlCommand cmd = new SqlCommand(myQuery, con);
    DataTable dt = new DataTable();
    dt.Load(cmd.ExecuteReader());
    con.Close();
