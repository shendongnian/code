    using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString))
    {
        string deleteQuery = @"DELETE FROM [dbo].[Customer] WHERE FirstName = @FirstName AND LastName = @LastName";
        var result = db.Execute(deleteQuery, new
        {
            customerModel.FirstName,
            customerModel.LastName
        });
    }
