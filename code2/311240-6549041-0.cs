	using System.Linq.Expressions;
	public static class SearchEngine<T>
	{
		class IandT<T>
		{
			public string Term { get; set; }
			public T Item { get; set; }
		}
		public static IEnumerable<T> Find(
					  IQueryable<T> items,
					  string query,
					  params Expression<Func<T, string>>[] properties)
		{
			var terms = query.Split(new char[] { ' ' },
								    StringSplitOptions.RemoveEmptyEntries);
			var numberOfParts = terms.Length;
			Expression<Func<IandT<T>, bool>> falseCond = a => false;
			Func<Expression<Func<IandT<T>, bool>>,
				 Expression<Func<IandT<T>, bool>>,
				 Expression<Func<IandT<T>, bool>>> combineOr = 
					(f, g) => (b) => f.Expand(b) || g.Expand(b);
			var criteria = falseCond;
			foreach (var prop in properties)
			{
				var currentprop = prop;
				Expression<Func<IandT<T>, bool>> current = c => 
						currentprop.Expand(c.Item).IndexOf(c.Term) != -1;
				criteria = combineOr(criteria.Expand(), current.Expand());
			}
			return from p in items.ToExpandable()
				   from t in terms
				   where criteria.Expand(new IandT<T> { Item = p, Term = t })
				   group p by p into g
				   where g.Count() == numberOfParts
				   select g.Key;
		}
	}
