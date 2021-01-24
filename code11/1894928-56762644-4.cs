	public class ProcessBassTypeClass : IProcessBaseType
	{
		private Dictionary<Type, Delegate> _processors = new Dictionary<Type, Delegate>();
		
		public void AttachProcessor<T>(Action<T> processor) where T : BaseTypeClass
		{
			_processors[typeof(T)] = processor;
		}
		
		public void Process<T>(T baseType) where T : BaseTypeClass
		{
			if (_processors.ContainsKey(typeof(T)))
			{
				((Action<T>)(_processors[typeof(T)])).Invoke(baseType);
			}
			else
			{
				throw new NotSupportedException();
			}
		}
	}
