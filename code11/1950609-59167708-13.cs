    try
    {
        foreach(var result in BaseDadosSQL.GetClubLogin(player.SocialClubName))
        {
            Console.WriteLine("Result " + result["username"]);
        }
    }
    catch (MySqlException ex)
    {
       NAPI.Util.ConsoleOutput($"[BaseDados][Erro] {ex.Message}");
    }
