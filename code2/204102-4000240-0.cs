		/// <summary>
		/// Converts the delegate to <see cref="TDelegate"/>, provided the types are compatible. Can use
		/// variance of delegate typing in .NET 4 for a speedy conversion. Otherwise, uses Delegate.CreateDelegate
		/// to create a new delegate with the appropriate signature. 
		/// </summary>
		/// <typeparam name="TDelegate">The target delegate type.</typeparam>
		/// <param name="delegate">The @delegate.</param>
		/// <returns></returns>
		public static TDelegate ConvertDelegate<TDelegate>(Delegate @delegate) where TDelegate : class
		{
			ArgumentValidator.AssertIsNotNull(() => @delegate);
			var targetType = typeof(TDelegate);
			ArgumentValidator.AssertIsDelegateType(() => targetType);
			var currentType = @delegate.GetType();
			if (targetType.IsAssignableFrom(currentType))
			{
				return @delegate as TDelegate; // let's skip as much of this as we can.
			}
			
			var currentMethod = currentType.GetMethod("Invoke");
			var targetMethod = targetType.GetMethod("Invoke");
			if (!AreDelegateInvokeMethodsCompatible(currentMethod, targetMethod, true))
			{
				throw new ArgumentException(string.Format("{0} is incompatible with {1}.", currentType, targetType), ExpressionHelper.GetMemberName(() => @delegate));
			}
			var invocationList = @delegate.GetInvocationList();
			return DelegateHelper.Combine(@delegate.GetInvocationList()
				.Select(d => IsMethodRunTimeGenerated(d.Method) ?
							GetDynamicMethodFromMethodInfo(d.Method).CreateDelegate<TDelegate>(d.Target) :
							DelegateHelper.CreateDelegate<TDelegate>(d.Target, d.Method)).ToArray());
		}
		#region Private Static Variables 
		private static Type s_RTDynamicMethodType = Type.GetType("System.Reflection.Emit.DynamicMethod+RTDynamicMethod",false,true);
		private static Func<MethodInfo, DynamicMethod> s_GetDynamicMethodDelegate = CreateGetDynamicMethodDelegate();
		#endregion Private Static Variables 
		private static Func<MethodInfo, DynamicMethod> CreateGetDynamicMethodDelegate()
		{
			var param = Expression.Parameter(
							typeof(MethodInfo),
							typeof(MethodInfo).Name
			);
			var expression = Expression.Lambda<Func<MethodInfo, DynamicMethod>>(
				Expression.Field(
					Expression.Convert(
						param,
						s_RTDynamicMethodType
					),
					s_RTDynamicMethodType.GetField("m_owner", BindingFlags.NonPublic | BindingFlags.Instance)
				),
				param
				);
			return expression.Compile();
		}
