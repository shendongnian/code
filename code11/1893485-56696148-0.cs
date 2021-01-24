public class ChatHub : Hub
{
    private readonly ILogger&lt;ChatHub&gt; _logger;
    public ChatHub(<b>ILogger&lt;ChatHub&gt; logger</b>)
    {
        <b>this._logger = logger;</b>
    }
    public async Task SendMessage(string user, string message)
    {
        <b>this._logger.LogInformation($"send message to client\r\n {user}\t{message}");</b>
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
