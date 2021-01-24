    using (var connection = new SqlConnection(_ConnectionString))
    {
        connection.Open();
        {
           string query = @"select P.Name, C.Name from tblCategory C JOIN P ON C.Id=P.CategoryId";
           result = (await connection.QueryAsync<MyDto>(query)).ToList();
         }
    }
