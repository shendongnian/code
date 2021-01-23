    public abstract class PagedQuery<TInput, TOutput>
        : IQuery<TInput, IEnumerable<TOutput>>
    {
        public IEnumerable<TOutput> Execute(TInput input)
        {
            return Enumerable.Empty<TOutput>(); // error here..
        }
    }
