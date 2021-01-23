    var result = new List<string>();
    var myconstring = "SERVER=localhost;DATABASE=alicosms;UID=root;PASSWORD=;";
    using (var con = new MySqlConnection(myconstring))
    using (var cmd = con.CreateCommand())
    {
        con.Open();
        cmd.CommandText = "SELECT flag FROM sms_data_bankasia group by flag";
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                result.Add(reader.GetString(reader.GetOrdinal("flag")));
            }
        }
    }
    string[] a = result.ToArray();
