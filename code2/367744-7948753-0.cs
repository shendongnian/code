	public static IQueryable<TResult> OptionalJoin<TOuter, TInner, TKey, TResult>(
		this IQueryable<TOuter> outer,
		bool condition,
		IEnumerable<TInner> inner,
		Expression<Func<TOuter, TKey>> outerKeySelector,
		Expression<Func<TInner, TKey>> innerKeySelector,
		Expression<Func<TOuter, TInner, TResult>> joinResultSelector,
		Expression<Func<TOuter, TResult>> outerResultSelector)
	{
		return condition
			? outer.Join(inner,
				outerKeySelector,
				innerKeySelector,
				joinResultSelector)
			: outer.Select(outerResultSelector);
	}
