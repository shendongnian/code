    if (field2.Key.ToString() == "players")
    {
         var playerdetails= JArray.Parse(field2.Value.ToString());
         foreach (var player in playerdetails)
         {
               Console.WriteLine(player["player_id"]);                       
               Console.WriteLine(player["player_name"]);                                  
         }
    }
