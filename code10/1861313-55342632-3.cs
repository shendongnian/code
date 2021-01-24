    void DoStuff<IBaseEntity>(...) 
    {
       IQueryable<IBaseEntity> queryable = ... // given
       var sortedQueryable = queryable.OrderBy(e=> e.Id);
       ...
    }
