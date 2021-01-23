	[ContentProperty("Items")]
	public class GenericCollectionFactoryExtension : MarkupExtension
	{
		public Type Type { get; set; }
		
		private readonly List<Type> _TypeArguments = new List<Type>();
		public List<Type> TypeArguments { get { return _TypeArguments; } }
		private readonly List<Object> _Items = new List<Object>();
		public List<Object> Items { get { return _Items; } }
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			var genericType = Type.MakeGenericType(_TypeArguments.ToArray());
			var list = Activator.CreateInstance(genericType) as IList;
			if (list == null) throw new Exception("Instance type does not implement IList");
			foreach (var item in Items)
			{
				list.Add(item);
			}
			return list;
		}
	}
