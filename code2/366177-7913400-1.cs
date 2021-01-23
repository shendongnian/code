    IList<TEntity> resultCollection = ((IRepository<TEntity, TCtx>)this).SelectAll(new Specification<TEntity>(lambdaExpr));
    ((IRepository<TEntity, TCtx>)this)
    if (null != resultCollection && resultCollection.Count() > 0)
    {
       //return valid single result 
       return resultCollection.First();
    }
    return null;
    // with following lines
      
    foreach(TEntity entity in ((IRepository<TEntity, TCtx>)this).SelectAll(new Specification<TEntity>(lambdaExpr)))
        return entity;
    return null;
