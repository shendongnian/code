    using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
    {
        string insertQuery = @"UPDATE VirtualProduct SET ProductImageId = @Id WHERE Name='@Header';";
        if (db.State==ConnectionState.Closed)
        {                      
            db.Open();   
        }
        var result = db.Execute(insertQuery, virtualProduct);
    }
