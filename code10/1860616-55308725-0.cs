	public static bool ExpressionContains(string s, string sub) {
		var cmi = typeof(String).GetMethod("Contains", new[] { typeof(string) });
		var body = Expression.Call(
            Expression.Constant(s),
            cmi,
            Expression.Constant(sub));
		return Expression.Lambda<Func<bool>>(body).Compile().Invoke();
	}
