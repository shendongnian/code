    public virtual Func<int> Create(TCreateDto entityDto)
    {
        var entity = Mapper.Map<TEntity>(entityDto);
        Repository.Create(entity);
        return () => entity.Id; // <--
    }
