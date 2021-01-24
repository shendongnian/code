	var query =
		Observable
			.Create<char?>(o =>
			{
				IDisposable inner = null;
				IDisposable subscription = 
					mainValues
						.Publish(mvs =>
						{
							var q = new System.Collections.Generic.Queue<char>();
							inner = mvs.Subscribe(mv => q.Enqueue(mv));
							return clockValues.Select(x => q.Count > 0 ? q.Dequeue() : (char?)null);
						})
						.Subscribe(o);
				return new CompositeDisposable(inner, subscription);
			});
	query.Subscribe(x => Console.WriteLine(x));
	scheduler.Start();
