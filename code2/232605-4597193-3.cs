    public class MyQueryable<T> : IOrderedQueryable<T>
    {
     public MyQueryable(IQueryable<T> toWrap)
      : this(equipment, Expression.Constant(equipment.AsQueryable()))
     {
     }
    
     public MyQueryable(IQueryable<T> toWrap, Expression expression)
     {
      Wrapped = toWrap;
      Provider = new MyProvider<T>(toWrap);
      Expression = expression;
     }
    
     public IEnumerator<TModel> GetEnumerator()
     {
      return Wrapped.GetEnumerator();
     }
    
     IEnumerator IEnumerable.GetEnumerator()
     {
      return GetEnumerator();
     }
    
     public Expression Expression { get; private set; }
    
     public Type ElementType
     {
      get { return typeof(T); }
     }
    
     public IQueryProvider Provider { get; private set; }
     internal IQueryable<T> Wrapped { get; set; }
    }
