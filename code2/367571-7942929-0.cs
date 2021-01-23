    interface IHelper { object Fetch(object key); }
    class Helper<T> : IHelper where T : Record<T>, IBaseRecord, new()
    {
        public object Fetch(object key) { return Record<T>.FetchById(key); }
    }
    public virtual T Get<T>(object primaryKey) where T : IDalRecord, new()
    {
        var helperType = typeof( Helper<> ).MakeGenericType( typeof( T ) ); // This will throw an exception if T does not satisfy Helper's where clause
        var helper = Activator.CreateInstance( helperType ) as IHelper; 
        return (T) helper.Fetch(primaryKey);
    }
