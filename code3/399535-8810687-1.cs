    public SomeMethod<T>(string repositoryName) where T : Entity, IOrderedEntity
    {
        List<T> entityList = repository<T>.All().OrderBy(x => x.DisplayOrder).ToList();
        foreach (var entityRecord in entityList)
        {
            //... do work ...
        }
    }
