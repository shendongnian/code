			public void Intercept(IInvocation invocation)
			{
				var timer = Stopwatch.StartNew();
				// i think you want this to proceed with the invocation...
				invocation.Proceed();
				timer.Stop();
				// check if threshold is exceeded
				if (timer.Elapsed > _threshold)
				{
				    // log it to logger of choice
				}
			}
