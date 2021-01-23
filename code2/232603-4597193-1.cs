    public class MyQuerayble<T> : IOrderedQueryable<T>
    {
    	public MyQuerayble(IQuerable<T> toWrap)
    		: this(equipment, Expression.Constant(equipment.AsQueryable()))
    	{
    	}
    
    	public MyQuerayble(IQuerable<T> toWrap, Expression expression)
    	{
    		Equipment = equipment;
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
    	internal IQuerable<T> Wrapped { get; set; }
    }
