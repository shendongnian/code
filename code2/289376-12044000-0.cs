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
		private MethodInfo FindMethod(Type baseType, string methodName)
		{
			MethodInfo method = null;
			if (!cache.TryGetValue(methodName, out method))
			{
				var methods = baseType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
				foreach (var info in methods)
				{
					if (info.IsFinal && info.IsPrivate) //explicit interface implementation
					{
						if (info.Name == methodName || info.Name.EndsWith("." + methodName))
						{
							method = info;
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
			MethodInfo method = FindMethod(baseType, methodName);
			return (RT)method.Invoke(obj, null);
		}
	}   //public static class BaseClassExplicitInterfaceInvoker<T>
