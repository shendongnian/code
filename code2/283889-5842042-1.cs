    string promo = "SELECT title FROM promo";
    MySqlCommand promoCommand = new MySqlCommand(promo, sqlConn);
    try
    {
        sqlConn.Open();
        sqlReader = promoCommand.ExecuteReader();
        while (sqlReader.Read())
        {
                prom = sqlReader.GetValue(0).ToString();
                prmopaginaBX.Items.Add(prom);
        }
        sqlReader.Close();
    }
