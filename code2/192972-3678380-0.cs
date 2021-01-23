    SqlCommand cmd = new SqlCommand(); 
    cmd.Connection = connection; 
    cmd.CommandType = System.Data.CommandType.Text; 
    string sql = "SELECT * FROM ForumThread WHERE ";
    // assuming you have at least 1 item always in wordsFromTxtSearche
    int count = 1;
    foreach (string word in wordsFromTxtSearche)
    {
        if (count > 1) sql += " AND ";
        sql += string.Format("Text LIKE @Text{0}", count.ToString());
        cmd.Parameters.Add(new SqlParameter("@Text{0}" + count.ToString(),
            string.Format("%{0}%", word)));
        count++;
    }
    cmd.CommandText = sql;
                 
