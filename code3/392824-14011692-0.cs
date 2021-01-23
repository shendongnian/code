	public static object GetProperty(object o, string member)
	{
		if(o == null) throw new ArgumentNullException("o");
		if(member == null) throw new ArgumentNullException("member");
		Type scope = o.GetType();
		IDynamicMetaObjectProvider provider = o as IDynamicMetaObjectProvider;
		if(provider != null)
		{
			ParameterExpression param = Expression.Parameter(typeof(object));
			DynamicMetaObject mobj = provider.GetMetaObject(param);
			GetMemberBinder binder = (GetMemberBinder)Microsoft.CSharp.RuntimeBinder.Binder.GetMember(0, member, scope, new CSharpArgumentInfo[]{CSharpArgumentInfo.Create(0, null)});
			DynamicMetaObject ret = mobj.BindGetMember(binder);
			BlockExpression final = Expression.Block(
				Expression.Label(CallSiteBinder.UpdateLabel),
				ret.Expression
			);
			LambdaExpression lambda = Expression.Lambda(final, param);
			Delegate del = lambda.Compile();
			return del.DynamicInvoke(o);
		}else{
			return o.GetType().GetProperty(member, BindingFlags.Public | BindingFlags.Instance).GetValue(o, null);
		}
	}
