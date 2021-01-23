    public class MappedExpressionQuery<T> : IOrderedQueryable<T>
    {
      private IQueryable<T> baseQuery;
      private MappedExpressionQueryProvider<T> provider;
      public MappedExpressionQuery(IQueryable<T> query, ExpressionVisitor expressionMap)
      {
        baseQuery = query;
        provider = new MappedExpressionQueryProvider<T>(query.Provider, expressionMap);
      }
      #region IOrderedQueryable<T> Members
      public IEnumerator<T> GetEnumerator()
      {
        return baseQuery.Provider.CreateQuery<T>(provider.ExpressionMap.Visit(baseQuery.Expression)).GetEnumerator();
      }
      IEnumerator IEnumerable.GetEnumerator()
      {
        return baseQuery.Provider.CreateQuery(provider.ExpressionMap.Visit(baseQuery.Expression)).GetEnumerator();
      }
      public Type ElementType
      {
        get { return baseQuery.ElementType; }
      }
      public Expression Expression
      {
        get { return baseQuery.Expression; }
      }
      public IQueryProvider Provider
      {
        get { return provider; }
      }
      #endregion
    }
    public class MappedExpressionQueryProvider<T> : IQueryProvider
    {
      public ExpressionVisitor ExpressionMap { get; private set; }
      private IQueryProvider baseProvider;
      public MappedExpressionQueryProvider(IQueryProvider baseProvider, ExpressionVisitor expressionMap)
      {
        this.ExpressionMap = expressionMap;
        this.baseProvider = baseProvider;
      }
      #region IQueryProvider Members
      public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
      {
        return new MappedExpressionQuery<TElement>(baseProvider.CreateQuery<TElement>(expression), ExpressionMap);
      }
      public IQueryable CreateQuery(Expression expression)
      {
        throw new NotImplementedException();
      }
      public TResult Execute<TResult>(Expression expression)
      {
        return baseProvider.Execute<TResult>(ExpressionMap.Visit(expression));
      }
      public object Execute(Expression expression)
      {
        return baseProvider.Execute(ExpressionMap.Visit(expression));
      }
      #endregion
    }
