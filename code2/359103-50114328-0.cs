    public interface IOrderer<TItem>
    {
    	IOrderedQueryable<TItem> Apply(IQueryable<TItem> source);
    }
    
    public class OrderBy<TItem, TType> : IOrderer<TItem>
    {
    	private Expression<Func<TItem, TType>> _orderExpr;
    	public OrderBy(Expression<Func<TItem, TType>> orderExpr)
    	{
    		_orderExpr = orderExpr;
    	}
    
    	public IOrderedQueryable<TItem> Apply(IQueryable<TItem> source)
    	{
    		return source.OrderBy(_orderExpr);
    	}
    }	
    
    public class ThenBy<TItem, TType> : IOrderer<TItem>
    {
    	private Expression<Func<TItem, TType>> _orderExpr;
    	public ThenBy(Expression<Func<TItem, TType>> orderExpr)
    	{
    		_orderExpr = orderExpr;
    	}
    
    	public IOrderedQueryable<TItem> Apply(IQueryable<TItem> source)
    	{
    		return ((IOrderedQueryable<TItem>)source).ThenBy(_orderExpr);
    	}
    }	
    
    public class OrderCoordinator<TItem>
    {
    	public List<IOrderer<TItem>> Orders { get; private set; } = new List<IOrderer<TItem>>();
    
    	public IQueryable<TItem> ApplyOrder(IQueryable<TItem> source)
    	{
    		foreach (IOrderer<TItem> orderer in Orders)
    		{
    			source = orderer.Apply(source);
    		}
    		return source;
    	}
    
    	public OrderCoordinator<TItem> OrderBy<TValueType>(Expression<Func<TItem, TValueType>> orderByExpression)
    	{
    		Orders.Add(new OrderBy<TItem, TValueType>(orderByExpression));
    		return this;
    	}
    
        // Can add more sort calls over time
    	public OrderCoordinator<TItem> ThenBy<TValueType>(Expression<Func<TItem, TValueType>> orderByExpression)
    	{
    		Orders.Add(new ThenBy<TItem, TValueType>(orderByExpression));
    		return this;
    	}
    }	
