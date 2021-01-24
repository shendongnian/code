	public interface IProcessBaseType
	{
		void Process(BaseTypeClass baseType);
	}
	public interface IProcessBaseType<T> : IProcessBaseType where T : BaseTypeClass
	{
		  void Process(T baseType);
	}
