    public async Task<User> UserFromEmail(string email)
    {
        Dictionary<int, User> result = new Dictionary<int, User>();
    
        string query = @"
                SELECT u.*, r.*
                FROM [User] u JOIN [UserRole] ur on u.UserId = ur.UserId
                              JOIN [Roles] r on ur.RoleId = r.Id
                WHERE u.Email = @email;";
        using (IDbConnection cnn = OpenConnection())
        {
            var users = await cnn.QueryAsync<User, Role, User>(query, (u, r) =>
            {
                // this lambda is called for each record retrieved by Dapper
                // passing a user and a role and expecting to return a user
                // we look if the user is already in the dictionary and add roles 
                // to that user.
                if (!result.ContainsKey(u.UserId))
                    result.Add(u.UserId, u);
                User working = result[u.UserId];
                working.roles.Add(r);
                return u;
            }, new { email }, splitOn: "RoleId");
    
            // Return the first element in the dictionary
            if (result.Values.Count > 0)
                return result.Values.First();
            else
                return null;
        }
    }
