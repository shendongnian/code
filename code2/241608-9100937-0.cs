    public class SortExpression<T>
    {
        private Tuple<Expression<Func<T, object>>, SortOrder> tuple;        
        public SortExpression( Expression<Func<T, object>> expression, SortOrder order =SortOrder.Ascending )
        {
            tuple = new Tuple<Expression<Func<T,object>>, SortOrder>(expression, order);
        }
        public Expression<Func<T, object>> Expression {
            get { return tuple.Item1; }
        }
        public SortOrder Order {
            get { return tuple.Item2; }
        }
    }
