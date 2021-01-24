    //Guessing at type and length here. Use the actual type and length from the database
    var p = new MySqlParameter("@SocialClub", MySqlDbType.VarString, 20);
    p.Value = player.SocialClubName;
    try
    {
        var asd = DB.QueryResult($"SELECT `socialclub`,`username`,`password` FROM contas WHERE socialclub = @SocialClub", p);
        foreach(var result in asd)
        {
            Console.WriteLine("Result " + result["username"]);
        }
    }
    catch (MySqlException ex)
    {
       NAPI.Util.ConsoleOutput($"[BaseDados][Erro] {ex.Message}");
    }
