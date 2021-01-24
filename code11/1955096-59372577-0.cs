    public abstract class BaseSearchProperty <TEntity,TFilter> : ISearchResultProperty<TEntity>
    {       
        public virtual List<AppliedFilter> BuildFilter(TFilter value)
        {
            return new List<AppliedFilter>();
        }
    } 
