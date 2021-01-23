    while (reader.Read())
    {
        // I'm guessing about the type here
        Player player = new Player();
        player.Name = reader["Name"].ToString();
        player.Number = Convert.ToInt32(reader["Number"].ToString());
        //push to list
        PlayerList.Add(player);
    }
