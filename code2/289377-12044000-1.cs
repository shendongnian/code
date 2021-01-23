	interface I   
	{   
		int M();   
	} 
	
	class A : I   
	{   
		int I.M() { return 1; }   
	} 
	
	class B : A, I   
	{   
		BaseClassExplicitInterfaceInvoker<B> invoker = new BaseClassExplicitInterfaceInvoker<B>();
		int I.M() { return invoker.Invoke<int>(this, "M") + 2; }   
	}
	public class BaseClassExplicitInterfaceInvoker<T>
	{
		private Dictionary<string, MethodInfo> cache = new Dictionary<string, MethodInfo>();
		private Type baseType = typeof(T).BaseType;
		private MethodInfo FindMethod(string methodName)
		{
			MethodInfo method = null;
			if (!cache.TryGetValue(methodName, out method))
			{
				var methods = baseType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
				foreach (var methodInfo in methods)
				{
					if (methodInfo.IsFinal && methodInfo.IsPrivate) //explicit interface implementation
					{
						if (methodInfo.Name == methodName || methodInfo.Name.EndsWith("." + methodName))
						{
							method = methodInfo;
							break;
						}
					}
				}   
				cache.Add(methodName, method);
			}
			return method;
		}
		public RT Invoke<RT>(T obj, string methodName)
		{            
			MethodInfo method = FindMethod(methodName);
			return (RT)method.Invoke(obj, null);
		}
	}   //public static class BaseClassExplicitInterfaceInvoker<T>
