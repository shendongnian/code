	public class Program
	{
		public static void Main()
		{
			var internalType = typeof(PublicTypeInAnotherAssembly).Assembly.GetType("Full name of internal type: System.Internals.IInterface");
			var result = new InterfaceImplementer(internalType, InterfaceCalled).GetTransparentProxy();
		}
		static object InterfaceCalled(MethodInfo info)
		{
			// Implement logic.
			Console.WriteLine($"{info.Name}: Did someone call an internal method?");
			// Return value matching info.ReturnType or null if void.
			return null;
		}
	}
	public class InterfaceImplementer : RealProxy, IRemotingTypeInfo
	{
		readonly Type _type;
		readonly Func<MethodInfo, object> _callback;
		public InterfaceImplementer(Type type, Func<MethodInfo, object> callback) : base(type)
		{
			_callback = callback;
			_type = type;
		}
		public override IMessage Invoke(IMessage msg)
		{
			var call = msg as IMethodCallMessage;
			if (call == null)
				throw new NotSupportedException();
			var method = (MethodInfo)call.MethodBase;
			return new ReturnMessage(_callback(method), null, 0, call.LogicalCallContext, call);
		}
		public bool CanCastTo(Type fromType, object o) => fromType == _type;
		public string TypeName { get; set; }
	}
