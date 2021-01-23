	public static IObservable<IEnumerable<T>> BufferWithInactivity<T>(
		this IObservable<T> source,
		TimeSpan inactivity,
		int maximumBufferSize)
	{
		return Observable.Create<IEnumerable<T>>(o =>
		{
			var gate = new object();
			var buffer = new List<T>();
			var mutable = new SerialDisposable();
			var subscription = (IDisposable)null;
			var scheduler = Scheduler.ThreadPool;
			
			Action dump = () =>
			{
				var bts = buffer.ToArray();
				buffer = new List<T>();
				if (o != null)
				{
					o.OnNext(bts);
				}
			};
			
			Action dispose = () =>
			{
				if (subscription != null)
				{
					subscription.Dispose();
				}
				mutable.Dispose();
			};
			
			Action<Action<IObserver<IEnumerable<T>>>> onErrorOrCompleted =
				onAction =>
				{
					lock (gate)
					{
						dispose();
						dump();
						if (o != null)
						{
							onAction(o);
						}
					}
				};
			
			Action<Exception> onError = ex =>
				onErrorOrCompleted(x => x.OnError(ex));
			
			Action onCompleted = () => onErrorOrCompleted(x => x.OnCompleted());
			
			Action<T> onNext = t =>
			{
				lock (gate)
				{
					buffer.Add(t);
					if (buffer.Count == maximumBufferSize)
					{
						dump();
						mutable.Disposable = Disposable.Empty;
					}
					else
					{
						mutable.Disposable = scheduler.Schedule(inactivity, () =>
						{
							lock (gate)
							{
								dump();
							}
						});
					}
				}
			};
			
			subscription =
				source
					.ObserveOn(scheduler)
					.Subscribe(onNext, onError, onCompleted);
					
			return () =>
			{
				lock (gate)
				{
					o = null;
					dispose();
				}
			};
		});
	}
