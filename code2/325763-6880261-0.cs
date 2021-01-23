    public IQueryable<T> ListGames<T>() where T : IGame
    {
        return _gameLookup
            .Select(d => d.Value)
            .OfType<T>()
            .AsQueryable();
    }
