    protected DbSet<T> Objects { get; private set; }
    protected YourDatabaseContext Context { get; private set; }
    public virtual T GetByID( int id, params string[] children )
    {
        if( children == null || children.Length == 0 )
        {
            return Objects.SingleOrDefault( e => e.ID == id );
        }
        DbQuery<T> query = children.Aggregate<string, DbQuery<T>>( Objects, ( current, child ) => current.Include( child ) );
        return query.SingleOrDefault( e => e.ID == id );
    }
