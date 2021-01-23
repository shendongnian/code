    public IQueryable<T> ListGames<T>() where T : IGame
    {
        return _gameLookup.Values
            .OfType<T>()
            .AsQueryable();
    }
