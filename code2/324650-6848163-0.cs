        public interface IQuery<TInput, TOutput>
        {
            IEnumerable<TOutput> Execute(TInput input);
        }
        public abstract class PagedQuery<TInput, TOutput> : IQuery<TInput, TOutput>
        {
            public IEnumerable<TOutput> Execute(TInput input)
            {
                return Enumerable.Empty<TOutput>();
            }
        }
