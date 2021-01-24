	public class Program
	{
		private IHost _host;
		public Program()
		{
			_host = new HostBuilder()
				.Build();
		}
		public async Task StartAsync()
		{
			_host.StartAsync();
		}
		public async Task StopAsync()
		{
			using (_host)
			{
				await _host.StopAsync(TimeSpan.FromSeconds(5));
			}
		}
	}
