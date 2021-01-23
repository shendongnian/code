    using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString))
    {
        string deleteQuery = @"DELETE FROM [dbo].[Customer] WHERE FirstName = '" + firstName + "'" + "AND LastName = '" + lastName + "'";
        var result = db.Execute(deleteQuery);
    }
