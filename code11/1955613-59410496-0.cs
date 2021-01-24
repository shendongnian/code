	public class DeviceReader_Helper {
		private readonly IHubContext<DeviceReaderHub> _hubContext;
        // you can obtain hubContext either from constructor DI, or service locator pattern with an IServiceProvider
		public DeviceReader_Helper(IHubContext<DeviceReaderHub> hubContext) {
			_hubContext = hubContext;
		}
		public async Task SendMessage(string message) {
			await _hubContext.Clients.All.SendAsync("onRead", message);
		}
	}
