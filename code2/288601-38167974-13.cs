    using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString))
    {
        string updateQuery = @"UPDATE [dbo].[Customer] SET IsActive = @IsActive WHERE FirstName = @FirstName AND LastName = @LastName";
        var result = db.Execute(updateQuery, new
        {
            isActive,
            customerModel.FirstName,
            customerModel.LastName
        });
    }
