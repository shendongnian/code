    DbConnectionStringBuilder db = new DbConnectionStringBuilder();
    db.ConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
    var username = db["User Id"].ToString();
    var password = db["Password"].ToString();
    
    
