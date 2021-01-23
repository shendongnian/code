    public class OrderByExpression<TEntity, TOrderBy> : IOrderByExpression<TEntity>
        where TEntity : class
    {
        private Expression<Func<TEntity, TOrderBy>> _expression;
        private bool _descending;
        public OrderByExpression(Expression<Func<TEntity, TOrderBy>> expression,
            bool descending = false)
        {
            _expression = expression;
            _descending = descending;
        }
        public IOrderedQueryable<TEntity> ApplyOrderBy(
            IQueryable<TEntity> query)
        {
            if (_descending)
                return query.OrderByDescending(_expression);
            else
                return query.OrderBy(_expression);
        }
        public IOrderedQueryable<TEntity> ApplyThenBy(
            IOrderedQueryable<TEntity> query)
        {
            if (_descending)
                return query.ThenByDescending(_expression);
            else
                return query.ThenBy(_expression);
        }
    }
