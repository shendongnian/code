    using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString))
    {
        string updateQuery = string.Format("UPDATE [dbo].[Customer] SET IsActive = {0} WHERE FirstName = '{1}' AND LastName = '{2}'", isActive, firstName, lastName);
        var result = db.Execute(updateQuery);
    }
