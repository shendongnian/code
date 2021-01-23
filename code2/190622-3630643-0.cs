    public abstract class TypedTableBase<T> : System.Data.TypedTableBase<T>
        where T : DataRow
    {
        public Expression<Func<T, bool>> RowCriteria(Expression<Func<T, bool>> criteria)
        {
            return criteria;
        }
    }
