    string[] words = txtSearche.Split(' ', StringSplitOption.RemoveEmptyEntries);
    string[] paramNames = Enumerable.Range(1, words.Length)
        .Select(i => "p" + i)
        .ToArray();
    string likeClause = string.Join("AND ",
         paramNames.Select(name => "col like '%' + " + name + " + '%'");
    SqlParmeter[] params = Enumerable.Range(1, words.Length)
        .Select(i => new SqlParameter(paramNames[i], words[i]))
        .ToArray();
    SqlCommand cmd = new SqlCommand();
    cmd.Connection = connection;
    cmd.CommandType = System.Data.CommandType.Text;
    cmd.CommandText = @"SELECT * FROM ForumThread WHERE " + likeClause;
    cmd.Parameters.AddRange(params);
