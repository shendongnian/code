    public virtual IList<TEntity> SelectOrderedList(
        params Expression<Func<TEntity, IComparable>>[] Orderers) {
        IOrderedQueryable<TEntity> TemporaryQueryable = null;
    
        foreach (Expression<Func<TEntity, IComparable>> Orderer in Orderers) {
            if (TemporaryQueryable == null) {
                TemporaryQueryable = this.ObjectSet.OrderBy(Orderer);
            } else {
                TemporaryQueryable = TemporaryQueryable.ThenBy(Orderer);
            };
        };
    
        return TemporaryQueryable.ToList();
    }
