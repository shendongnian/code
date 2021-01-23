    string strSQLconnection = 
    "Data Source=dbServer;Initial Catalog=yourDatabase;Integrated Security=True";
    SqlConnection con = new SqlConnection(strSQLconnection);
    SqlCommand sqlCommand = 
        new SqlCommand("SELECT * FROM tbl WHERE  ID = 'john' ", con);     
    con.Open();
 
    SqlDataReader reader = sqlCommand.ExecuteReader();
        
    GridView1.DataSource = reader;
    GridView1.DataBind();
}
