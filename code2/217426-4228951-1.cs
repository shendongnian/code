    public void Add<T>(EntityCollection<T> entities)
    {
        Repository<T> repo = entities.GetRepository();
        repo.Add(entities);
    }
