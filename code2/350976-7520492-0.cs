    public class QueryOverStub<TRoot, TSub> : IQueryOver<TRoot, TSub>
    {
        private readonly TRoot _singleOrDefault;
        private readonly IList<TRoot> _list;
        private readonly ICriteria _root = MockRepository.GenerateStub<ICriteria>();
        public QueryOverStub(IList<TRoot> list)
        {
            _list = list;
        }
        public QueryOverStub(TRoot singleOrDefault)
        {
            _singleOrDefault = singleOrDefault;
        }
        public ICriteria UnderlyingCriteria
        {
            get { return _root; }
        }
        public ICriteria RootCriteria
        {
            get { return _root; }
        }
        public IList<TRoot> List()
        {
            return _list;
        }
        public IList<U> List<U>()
        {
            throw new NotImplementedException();
        }
        public IQueryOver<TRoot, TRoot> ToRowCountQuery()
        {
            throw new NotImplementedException();
        }
        public IQueryOver<TRoot, TRoot> ToRowCountInt64Query()
        {
            throw new NotImplementedException();
        }
        public int RowCount()
        {
            return _list.Count;
        }
        public long RowCountInt64()
        {
            throw new NotImplementedException();
        }
        public TRoot SingleOrDefault()
        {
            return _singleOrDefault;
        }
        public U SingleOrDefault<U>()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<TRoot> Future()
        {
            return _list;
        }
        public IEnumerable<U> Future<U>()
        {
            throw new NotImplementedException();
        }
        public IFutureValue<TRoot> FutureValue()
        {
            throw new NotImplementedException();
        }
        public IFutureValue<U> FutureValue<U>()
        {
            throw new NotImplementedException();
        }
        public IQueryOver<TRoot, TRoot> Clone()
        {
            throw new NotImplementedException();
        }
        public IQueryOver<TRoot> ClearOrders()
        {
            return this;
        }
        public IQueryOver<TRoot> Skip(int firstResult)
        {
            return this;
        }
        public IQueryOver<TRoot> Take(int maxResults)
        {
            return this;
        }
        public IQueryOver<TRoot> Cacheable()
        {
            return this;
        }
        public IQueryOver<TRoot> CacheMode(CacheMode cacheMode)
        {
            return this;
        }
        public IQueryOver<TRoot> CacheRegion(string cacheRegion)
        {
            return this;
        }
        public IQueryOver<TRoot, TSub> And(Expression<Func<TSub, bool>> expression)
        {
            return this;
        }
        public IQueryOver<TRoot, TSub> And(Expression<Func<bool>> expression)
        {
            return this;
        }
        public IQueryOver<TRoot, TSub> And(ICriterion expression)
        {
            return this;
        }
        public IQueryOver<TRoot, TSub> AndNot(Expression<Func<TSub, bool>> expression)
        {
            return this;
        }
        public IQueryOver<TRoot, TSub> AndNot(Expression<Func<bool>> expression)
        {
            return this;
        }
        public IQueryOverRestrictionBuilder<TRoot, TSub> AndRestrictionOn(Expression<Func<TSub, object>> expression)
        {
            throw new NotImplementedException();
        }
        public IQueryOverRestrictionBuilder<TRoot, TSub> AndRestrictionOn(Expression<Func<object>> expression)
        {
            throw new NotImplementedException();
        }
        public IQueryOver<TRoot, TSub> Where(Expression<Func<TSub, bool>> expression)
        {
            return this;
        }
        public IQueryOver<TRoot, TSub> Where(Expression<Func<bool>> expression)
        {
            return this;
        }
        public IQueryOver<TRoot, TSub> Where(ICriterion expression)
        {
            return this;
        }
        public IQueryOver<TRoot, TSub> WhereNot(Expression<Func<TSub, bool>> expression)
        {
            return this;
        }
        public IQueryOver<TRoot, TSub> WhereNot(Expression<Func<bool>> expression)
        {
            return this;
        }
        public IQueryOverRestrictionBuilder<TRoot, TSub> WhereRestrictionOn(Expression<Func<TSub, object>> expression)
        {
            return new IQueryOverRestrictionBuilder<TRoot, TSub>(this, "prop");
        }
        public IQueryOverRestrictionBuilder<TRoot, TSub> WhereRestrictionOn(Expression<Func<object>> expression)
        {
            return new IQueryOverRestrictionBuilder<TRoot, TSub>(this, "prop");
        }
        public IQueryOver<TRoot, TSub> Select(params Expression<Func<TRoot, object>>[] projections)
        {
            return this;
        }
        public IQueryOver<TRoot, TSub> Select(params IProjection[] projections)
        {
            return this;
        }
        public IQueryOver<TRoot, TSub> SelectList(Func<QueryOverProjectionBuilder<TRoot>, QueryOverProjectionBuilder<TRoot>> list)
        {
            return this;
        }
        public IQueryOverOrderBuilder<TRoot, TSub> OrderBy(Expression<Func<TSub, object>> path)
        {
            return new IQueryOverOrderBuilder<TRoot, TSub>(this, path);
        }
        public IQueryOverOrderBuilder<TRoot, TSub> OrderBy(Expression<Func<object>> path)
        {
            return new IQueryOverOrderBuilder<TRoot, TSub>(this, path, false);
        }
        public IQueryOverOrderBuilder<TRoot, TSub> OrderBy(IProjection projection)
        {
            return new IQueryOverOrderBuilder<TRoot, TSub>(this, projection);
        }
        public IQueryOverOrderBuilder<TRoot, TSub> OrderByAlias(Expression<Func<object>> path)
        {
            return new IQueryOverOrderBuilder<TRoot, TSub>(this, path, true);
        }
        public IQueryOverOrderBuilder<TRoot, TSub> ThenBy(Expression<Func<TSub, object>> path)
        {
            return new IQueryOverOrderBuilder<TRoot, TSub>(this, path);
        }
        public IQueryOverOrderBuilder<TRoot, TSub> ThenBy(Expression<Func<object>> path)
        {
            return new IQueryOverOrderBuilder<TRoot, TSub>(this, path, false);
        }
        public IQueryOverOrderBuilder<TRoot, TSub> ThenBy(IProjection projection)
        {
            return new IQueryOverOrderBuilder<TRoot, TSub>(this, projection);
        }
        public IQueryOverOrderBuilder<TRoot, TSub> ThenByAlias(Expression<Func<object>> path)
        {
            return new IQueryOverOrderBuilder<TRoot, TSub>(this, path, true);
        }
        public IQueryOver<TRoot, TSub> TransformUsing(IResultTransformer resultTransformer)
        {
            return this;
        }
        public IQueryOverFetchBuilder<TRoot, TSub> Fetch(Expression<Func<TRoot, object>> path)
        {
            return new IQueryOverFetchBuilder<TRoot, TSub>(this, path);
        }
        public IQueryOverLockBuilder<TRoot, TSub> Lock()
        {
            throw new NotImplementedException();
        }
        public IQueryOverLockBuilder<TRoot, TSub> Lock(Expression<Func<object>> alias)
        {
            throw new NotImplementedException();
        }
        public IQueryOver<TRoot, U> JoinQueryOver<U>(Expression<Func<TSub, U>> path)
        {
            return new QueryOverStub<TRoot, U>(new List<TRoot>());
        }
        public IQueryOver<TRoot, U> JoinQueryOver<U>(Expression<Func<U>> path)
        {
            return new QueryOverStub<TRoot, U>(new List<TRoot>());
        }
        public IQueryOver<TRoot, U> JoinQueryOver<U>(Expression<Func<TSub, U>> path, Expression<Func<U>> alias)
        {
            return new QueryOverStub<TRoot, U>(_list);
        }
        public IQueryOver<TRoot, U> JoinQueryOver<U>(Expression<Func<U>> path, Expression<Func<U>> alias)
        {
            return new QueryOverStub<TRoot, U>(new List<TRoot>());
        }
        public IQueryOver<TRoot, U> JoinQueryOver<U>(Expression<Func<TSub, U>> path, JoinType joinType)
        {
            return new QueryOverStub<TRoot, U>(new List<TRoot>());
        }
        public IQueryOver<TRoot, U> JoinQueryOver<U>(Expression<Func<U>> path, JoinType joinType)
        {
            return new QueryOverStub<TRoot, U>(new List<TRoot>());
        }
        public IQueryOver<TRoot, U> JoinQueryOver<U>(Expression<Func<TSub, U>> path, Expression<Func<U>> alias, JoinType joinType)
        {
            return new QueryOverStub<TRoot, U>(new List<TRoot>());
        }
        public IQueryOver<TRoot, U> JoinQueryOver<U>(Expression<Func<U>> path, Expression<Func<U>> alias, JoinType joinType)
        {
            return new QueryOverStub<TRoot, U>(new List<TRoot>());
        }
        public IQueryOver<TRoot, U> JoinQueryOver<U>(Expression<Func<TSub, IEnumerable<U>>> path)
        {
            return new QueryOverStub<TRoot, U>(new List<TRoot>());
        }
        public IQueryOver<TRoot, U> JoinQueryOver<U>(Expression<Func<IEnumerable<U>>> path)
        {
            return new QueryOverStub<TRoot, U>(new List<TRoot>());
        }
        public IQueryOver<TRoot, U> JoinQueryOver<U>(Expression<Func<TSub, IEnumerable<U>>> path, Expression<Func<U>> alias)
        {
            return new QueryOverStub<TRoot, U>(new List<TRoot>());
        }
        public IQueryOver<TRoot, U> JoinQueryOver<U>(Expression<Func<IEnumerable<U>>> path, Expression<Func<U>> alias)
        {
            return new QueryOverStub<TRoot, U>(new List<TRoot>());
        }
        public IQueryOver<TRoot, U> JoinQueryOver<U>(Expression<Func<TSub, IEnumerable<U>>> path, JoinType joinType)
        {
            return new QueryOverStub<TRoot, U>(new List<TRoot>());
        }
        public IQueryOver<TRoot, U> JoinQueryOver<U>(Expression<Func<IEnumerable<U>>> path, JoinType joinType)
        {
            return new QueryOverStub<TRoot, U>(new List<TRoot>());
        }
        public IQueryOver<TRoot, U> JoinQueryOver<U>(Expression<Func<TSub, IEnumerable<U>>> path, Expression<Func<U>> alias, JoinType joinType)
        {
            return new QueryOverStub<TRoot, U>(new List<TRoot>());
        }
        public IQueryOver<TRoot, U> JoinQueryOver<U>(Expression<Func<IEnumerable<U>>> path, Expression<Func<U>> alias, JoinType joinType)
        {
            return new QueryOverStub<TRoot, U>(new List<TRoot>());
        }
        public IQueryOver<TRoot, TSub> JoinAlias(Expression<Func<TSub, object>> path, Expression<Func<object>> alias)
        {
            return this;
        }
        public IQueryOver<TRoot, TSub> JoinAlias(Expression<Func<object>> path, Expression<Func<object>> alias)
        {
            return this;
        }
        public IQueryOver<TRoot, TSub> JoinAlias(Expression<Func<TSub, object>> path, Expression<Func<object>> alias, JoinType joinType)
        {
            return this;
        }
        public IQueryOver<TRoot, TSub> JoinAlias(Expression<Func<object>> path, Expression<Func<object>> alias, JoinType joinType)
        {
            return this;
        }
        public IQueryOverSubqueryBuilder<TRoot, TSub> WithSubquery
        {
            get { return new IQueryOverSubqueryBuilder<TRoot, TSub>(this); }
        }
        public IQueryOverJoinBuilder<TRoot, TSub> Inner
        {
            get { return new IQueryOverJoinBuilder<TRoot, TSub>(this, JoinType.InnerJoin); }
        }
        public IQueryOverJoinBuilder<TRoot, TSub> Left
        {
            get { return new IQueryOverJoinBuilder<TRoot, TSub>(this, JoinType.LeftOuterJoin); }
        }
        public IQueryOverJoinBuilder<TRoot, TSub> Right
        {
            get { return new IQueryOverJoinBuilder<TRoot, TSub>(this, JoinType.RightOuterJoin); }
        }
        public IQueryOverJoinBuilder<TRoot, TSub> Full
        {
            get { return new IQueryOverJoinBuilder<TRoot, TSub>(this, JoinType.FullJoin); }
        }
    }
