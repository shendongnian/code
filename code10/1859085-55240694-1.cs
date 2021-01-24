    StringBuilder sb = new StringBuilder();
    using(MySqlConnection cons = new MySqlConnection(MyConString))
    {
         string query = "SELECT DISTINCT(skill2) AS skills FROM agentdetails";
         var command = new MySqlCommand(query, cons);
         cons.Open();
         var reader = command.ExecuteReader();
         
         // according to your comment, the result should be used as 
         // arguments for an IN clause.
         while(reader.Read())
           sb.AppendLine("'" + reader["skills"].ToString() + "',");
    }
    if(sb.Length > 0)
        sb.Length --; // To remove the last '
    return sb.ToString();
