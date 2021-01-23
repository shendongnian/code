    using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString))
    {
        string insertQuery = @"INSERT INTO [dbo].[Customer]([FirstName], [LastName], [State], [City], [IsActive], [CreatedOn]) VALUES (@FirstName, @LastName, @State, @City, @IsActive, @CreatedOn)";
        var result = db.Execute(insertQuery, new
        {
            customerModel.FirstName,
            customerModel.LastName,
            StateModel.State,
            CityModel.City,
            isActive,
            CreatedOn = DateTime.Now
        });
    }
