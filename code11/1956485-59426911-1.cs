    var tokens = new List<dynamic>() { new { tok = 1, logedinId = 2 }, new { tok = 1, logedinId = 2 } };
    var query = "INSERT INTO tokenlist(token, user_id) VALUES";
    
    SqlCommand cmd = new SqlCommand(query, new SqlConnection());
    
    for (int i = 0; i < tokens.Count; i++)
    {
        var tokName = $"@tok{i}";
        var logedinIdName = $"@logedinId{i}";
        var token = tokens[i];
        query += $" ({tokName}, {logedinIdName}),";
        cmd.Parameters.Add(new SqlParameter(tokName, SqlDbType.Int)).Value = token.tok;
        cmd.Parameters.Add(new SqlParameter(logedinIdName, SqlDbType.Int)).Value = token.logedinId;
    }
    
    if (tokens.Any())
    {
        query = query.Remove(query.Length - 1);
        query += ";";
    
        cmd.ExecuteNonQuery();
    }
