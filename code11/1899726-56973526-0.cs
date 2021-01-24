    public interface IStatisticsHub
	{
		Task Send(string message);
	}
	public class StatisticHub : Microsoft.AspNetCore.SignalR.Hub, IStatisticsHub
	{
		private readonly IHubContext<StatisticHub > _context;
		public StatisticHub(IHubContext<EventTypeHub> context)
		{
			_context = context;
		}
		public async Task Send(string message)
		{
			await _context.Clients.All.SendAsync("Send", message);
		}
	}
