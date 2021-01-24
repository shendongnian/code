	public class Dtos
	{
		private Dictionary<Type, Func<IEnumerable<EnumDto>>> _lists
			= new Dictionary<Type, Func<IEnumerable<EnumDto>>>();
	
		public void Add<T>(Func<IEnumerable<EnumDto>> factory)
		{
			_lists[typeof(T)] = factory;
		}
	
		public IEnumerable<EnumDto> Get<T>()
		{
			return _lists[typeof(T)]();
		}
	}
