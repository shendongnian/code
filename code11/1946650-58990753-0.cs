    using (MySqlDataReader rdr = cmd.ExecuteReader())
    {
       string CODE = string.Empty;
       while (rdr.Read())
       {
          string result= rdr.GetString(0);
          CODE = Regex.Match(result, @"\d+").Value;
       }
       return CODE ;
    }
