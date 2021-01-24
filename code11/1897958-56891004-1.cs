	namespace ExampleSvc
	{
		public class HandlerImpl : Example.Example.IAsync  
		{
			public Task<double> PingAsync(double input, CancellationToken cancel)
			{
				return Task.FromResult(input);
			}
		}
	}
