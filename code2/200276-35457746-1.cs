    string ID = "C8CA7EE2";
    string myQuery = "select * from ContactBase where contactid=" + "'" + ID + "'";
    string connectionString = ConfigurationManager.ConnectionStrings["CRM_SQL_CONN_UAT"].ToString(); 
    SqlConnection con = new SqlConnection(connectionString);
    con.Open();
    SqlCommand cmd = new SqlCommand(myQuery, con);
    DataTable dt = new DataTable();
    dt.Load(cmd.ExecuteReader());
    con.Close();
