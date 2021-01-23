    static void Main(string[] args)
    {
         using (var conn = new MySqlConnection("..."))
         using (var cmd = new MySqlCommand("...", conn))
         {
             conn.Open();
             using (MySqlDataReader dr = cmd.ExecuteReader())
             {
                 while (dr.Read())
                 {
                     // do something
                 }
             }
         }
    }
