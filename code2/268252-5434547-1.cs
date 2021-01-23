    ...
    public IQueryable<T> Table
    {
        get
        {
            return this.CreateQuery<T>(typeof(T).Name);
        }
    }
