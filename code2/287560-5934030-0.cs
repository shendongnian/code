    foreach (var game in model.Games)
    {
        if (!dataModel.Games.Any(e => e.GameId == game.Id))
        {
            DataGame dataGame = new DataGame();
            dataGame.GameId = game.Id;
            dataGame.GameName = game.Name;
            dataModel.Games.Add(dataGame);
        }
    }
