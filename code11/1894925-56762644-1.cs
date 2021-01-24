	public interface IProcessBaseType
	{
		void Process<T>(T baseType) where T : BaseTypeClass;
	}
	
	public class ProcessBassTypeClass : IProcessBaseType
	{
		public void Process<T>(T baseType) where T : BaseTypeClass
		{
			throw new NotImplementedException();
		}
	}
