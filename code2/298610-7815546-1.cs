    public static Game MapFromEditModelToGame(IGameRepository repo, AdminGameViewModel formData, Game newGame)
    {
        newGame.GameID = formData.GameID;
        newGame.GameTitle = formData.GameTitle;
        newGame.GenreID = formData.GenreID;
        newGame.LastModified = DateTime.Now;
        newGame.ReviewScore = (short)formData.ReviewScore;
        newGame.ReviewText = formData.ReviewText;
        newGame.Cons = String.Join("|", formData.Cons);
        newGame.Pros = String.Join("|", formData.Pros);
        newGame.Slug = formData.Slug;
        if (newGame.Platforms != null && newGame.Platforms.Count > 0)
        {
            var oldPlats = newGame.Platforms.ToArray();
            foreach (var oldPlat in oldPlats)
            {
                newGame.Platforms.Remove(oldPlat);
            }
        }
        foreach (var platId in formData.PlatformIDs)
        {
            var plat = repo.GetPlatform(platId);
            newGame.Platforms.Add(plat);
        }
        return newGame;
    }
