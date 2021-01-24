	class DynamicDictionaryWrapper : DynamicObject
	{
		protected readonly Dictionary<string,object> _source;
		
		public DynamicDictionaryWrapper(Dictionary<string,object> source)
		{
			_source = source;
		}
		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			result = null;
			return (_source.TryGetValue(binder.Name, out result));
		}
	}
