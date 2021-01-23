	using System.Runtime.CompilerServices;
	public static class Extensions
	{
		private static readonly ConditionalWeakTable<object, RefId> _ids = new ConditionalWeakTable<object, RefId>();
	
		public static Guid GetRefId<T>(this T obj) where T: class
		{
			if (obj == null)
				return default(Guid);
	
			return _ids.GetOrCreateValue(obj).Id;
		}
	
		private class RefId
		{
			public Guid Id { get; } = Guid.NewGuid();
		}
	}
