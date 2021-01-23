	public static IObservable<T> ToObservable<T>(
		this LegacyObject<T> @this)
	{
		return Observable.Create<T>(o =>
		{
			var gate = new object();
			lock (gate)
			{
				var list = new List<T>();
				var subject = new Subject<T>();
				var newItems = Observable
					.FromEventPattern<NewItemEventArgs<T>>(
						h => @this.NewItem += h,
						h => @this.NewItem -= h)
					.Select(ep => ep.EventArgs.NewItem);
				var inner = newItems.Subscribe(ni =>
				{
					lock (gate)
					{
						if (!list.Contains(ni))
						{
							list.Add(ni);
							subject.OnNext(ni);
						}
					}
				});
				list.AddRange(@this.GetItems());
				var outer = list.ToArray().ToObservable()
				    .Concat(subject).Subscribe(o);
				return new CompositeDisposable(inner, outer);
			}
		});
	}
