    strSql = "SELECT Roster.CharacterName, Roster.TotalTournamentsParticiaped, Roster.TotalWins, Roster.TotalLosses, Roster.Championships, Roster.InjuriesCaused, Roster.Injured " +
                 " FROM Roster " +
                 " INNER JOIN VideoGames " +
                 " ON VideoGames.VideoGame_ID = Roster.VideoGame_ID " +
                 " WHERE roster.VideoGame_ID = 2 ";
