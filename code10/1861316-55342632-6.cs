    void DoStuff<IBaseEntity>(...) 
    {
       IQueryable<IBaseEntity> queryable = ... // given
       var sortedQueryable = queryable.OrderById(e=> e.Id); //extension method
       ...
    }
