    foreach (var game in model.Games)
    {
        if (!dataModel.Games.Any(e => e.GameId == game.Id))
        {
            DataGame dataGame = new DataGame();
            dataGame.GameId = game.Id;
            dataGame.GameName = game.Name;
            
            context.Games.Attach(dataGame); // Now the context knows that it is not a new entity 
            dataModel.Games.Add(dataGame);
        }
    }
