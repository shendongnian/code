    public abstract class PagedQuery<TInput, TElement>
        : IQuery<TInput, IEnumerable<TElement>>
    {
        public IEnumerable<TElement> Execute(TInput input)
        {
            return Enumerable.Empty<TElement>();
        }
    }
