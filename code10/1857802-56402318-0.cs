		public static void Replace(Type original, Type target)
		{
			var targetMethods = GetStaticPublicMethods(target);
			foreach (var targetMethod in targetMethods)
			{
				var parameters = targetMethod.GetParameters().Select(x => x.ParameterType).ToArray();
				var originalMethod = original.GetMethod(targetMethod.Name, parameters);
				if (originalMethod != null)
				{
					SwapMethodBodies(originalMethod, targetMethod);
				}
				else
				{
					Debug.WriteLine(
						"*****************************************************************************************");
					Debug.WriteLine($"Method not found - {targetMethod.Name}");
					Debug.WriteLine(
						"*****************************************************************************************");
				}
			}
		}
		private static List<MethodInfo> GetStaticPublicMethods(Type t)
		{
			return t.GetMethods(BindingFlags.Public | BindingFlags.Static)
				.Distinct().ToList();
		}
The usage is now:
ShimHelper.Replace(
				typeof(ExtensionClass), 
				typeof(MockedExtensionClass));
I found this worked very nicely for AjaxRequestExtensions in MVC.
