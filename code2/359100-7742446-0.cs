    public interface IOrderer<T>
    {
        IOrderedQueryable<T> ApplyOrderBy(IQueryable<T> source);
        IOrderedQueryable<T> ApplyOrderByDescending(IQueryable<T> source);
        IOrderedQueryable<T> ApplyThenBy(IOrderedQueryable<T> source);
        IOrderedQueryable<T> ApplyThenByDescending(IOrderedQueryable<T> source);
    }
    public class Orderer<T, U> : IOrderer<T>
    {
        private Expression<Func<T, U>> _orderExpr;
        public Orderer(Expression<Func<T, U>> orderExpr) { _orderExpr = orderExpr; }
        public IOrderedQueryable<T> ApplyOrderBy(IQueryable<T> source)
        { return source.OrderBy(_orderExpr); }
        public IOrderedQueryable<T> ApplyOrderByDescending(IQueryable<T> source)
        { return source.OrderByDescending(_orderExpr); }
        public IOrderedQueryable<T> ApplyThenBy(IOrderedQueryable<T> source)
        { return source.ThenBy(_orderExpr); }
        public IOrderedQueryable<T> ApplyThenByDescending(IOrderedQueryable<T> source)
        { return source.ThenByDescending(_orderExpr); }
    }
    public class OrderCoordinator<T>
    {
        public List<IOrderer<T>> Orders { get; set; }
        public OrderCoordinator() { Orders = new List<IOrderer<T>>(); }
        //note, did not return IOrderedQueryable to support ability to return with empty Orders
        public IQueryable<T> ApplyOrders(IQueryable<T> source)
        {
            foreach (IOrderer<T> orderer in Orders)
            {
                source = orderer.ApplyOrderBy(source);
            }
            return source;
        }
    }
    public class Customer
    {
        public string Name { get; set; }
        public int FavNumber { get; set; }
    }
    public class Tester
    {
        public void Test()
        {
            OrderCoordinator<Customer> coord = new OrderCoordinator<Customer>();
            coord.Orders.Add(new Orderer<Customer, string>(c => c.Name));
            coord.Orders.Add(new Orderer<Customer, int>(c => c.FavNumber));
            IQueryable<Customer> query = Enumerable.Empty<Customer>().AsQueryable();
            query = coord.ApplyOrders(query);
            
            string result = query.Expression.ToString();
        }
    }
