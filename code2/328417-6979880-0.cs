    	private static readonly Func<InvokeMemberBinder, IList<Type>> GetTypeArguments;
		static TransparentObject()
		{
			var type = typeof(RuntimeBinderException).Assembly.GetTypes().Where(x => x.FullName == "Microsoft.CSharp.RuntimeBinder.CSharpInvokeMemberBinder").Single();
			var dynamicMethod = new DynamicMethod("@", typeof(IList<Type>), new[] { typeof(InvokeMemberBinder) }, true);
			var il = dynamicMethod.GetILGenerator();
			il.Emit(OpCodes.Ldarg_0);
			il.Emit(OpCodes.Castclass, type);
			il.Emit(OpCodes.Call, type.GetProperty("Microsoft.CSharp.RuntimeBinder.ICSharpInvokeOrInvokeMemberBinder.TypeArguments", BindingFlags.Instance | BindingFlags.NonPublic).GetGetMethod(true));
			il.Emit(OpCodes.Ret);
			GetTypeArguments = (Func<InvokeMemberBinder, IList<Type>>)dynamicMethod.CreateDelegate(typeof(Func<InvokeMemberBinder, IList<Type>>));
		}
    	public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
		{
			var method = typeof(T).GetMethod(binder.Name, BindingFlags.Public| BindingFlags.NonPublic | BindingFlags.Instance);
			if (method == null) throw new MissingMemberException(string.Format("Method '{0}' not found for type '{1}'", binder.Name, typeof(T)));
			var typeArguments = GetTypeArguments(binder);
			if (typeArguments.Count > 0) method = method.MakeGenericMethod(typeArguments.ToArray());
			result = method.Invoke(target, args);
			return true;
		}
