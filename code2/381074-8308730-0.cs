	public interface IFilter
	{
		IBusinessObject Execute(IBusinessObject input);
	}
	
	public interface IFilter<T, U> : IFilter
		where T : IBusinessObject
		where U : IBusinessObject
	{
		U Execute(T input);
	}
	
	public abstract class FilterBase<T, U> : IFilter<T, U>
		where T : IBusinessObject
		where U : IBusinessObject, new()
	{
		protected abstract U Process(T input);
	
		IBusinessObject IFilter.Execute(IBusinessObject input)
		{
			return this.Execute((T)input);
		}
		
		public U Execute(T input)
		{
			return Process(input);
		}
	}
	public interface IPipeline
	{
		IBusinessObject Execute(IBusinessObject input);
	
		IPipeline Register<T, U>(IFilter<T, U> filter)
			where T : IBusinessObject
			where U : IBusinessObject;
	}
	
	public class Pipeline : IPipeline
	{
		private List<IFilter> _filters = new List<IFilter>();
	
		public IBusinessObject Execute(IBusinessObject input)
		{
			var result = input;
			foreach (var filter in _filters)
			{
				result = filter.Execute(result);
			}
			return result;
		}
	
		public IPipeline Register<T, U>(IFilter<T, U> filter)
			where T : IBusinessObject
			where U : IBusinessObject
		{
			_filters.Add(filter);
			return this;
		}
	}
