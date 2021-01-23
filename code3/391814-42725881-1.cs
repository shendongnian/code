	public class PublicTypeInAnotherAssembly
	{
		public void Test(object proxy)
		{
			var internalInterface = (IInternalInterface)proxy;
			internalInterface.MethodOnInterface();
		}
	}
