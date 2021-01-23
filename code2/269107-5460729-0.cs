    string connectionString = WebConfigurationManager.ConnectionStrings["CRM2Sage"].ConnectionString;
    using(SqlConnection _con = new SqlConnection(connectionString))
    using(SqlCommand cmd = new SqlCommand("SELECT * FROM Products", _con))
    {
       // do your stuff here
    }
