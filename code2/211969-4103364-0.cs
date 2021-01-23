		public static MethodInfo Convert(this MethodInfo method,params Type[] DeclaringTypeArguments)
		{
			var baseType = method.DeclaringType.GetGenericTypeDefinition().MakeGenericType(DeclaringTypeArguments);
			return MethodInfo.GetMethodFromHandle(method.MethodHandle, baseType.TypeHandle) as MethodInfo;
		}
		public static void Main(String[] args)
		{
			List<Type> list = new List<Type>(); 
			Action<Type> action  = list.Add;
			Console.WriteLine(action.Method.Convert(typeof(string)));
			Console.Read();
		}
