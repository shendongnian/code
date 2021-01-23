	// Define other methods and classes here
	public interface IQuery<TInput, TOutput>
	{
		TOutput Execute(TInput input);
	}
	
	public class PagedQuery<TInput, TOutput> : IQuery<TInput, IEnumerable<TOutput>>
	{
		public IEnumerable<TOutput> Execute(TInput input)
		{
			return Enumerable.Empty<TOutput>();
		}
	}
