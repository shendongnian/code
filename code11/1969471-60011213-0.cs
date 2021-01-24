cs
Client = new DiscordSocketClient();
Client.MessageReceived += ClientOnMessageReceived;
await Client.LoginAsync(TokenType.Bot, "YOUR_BOT_TOKEN");
await Client.StartAsync();
Create some event handler. In the code below you can see how to fetch a couple of user and activity information.
cs
private async Task ClientOnMessageReceived(SocketMessage socketMessage)
{
	await Task.Run(() =>
	{
		//Activity is not from a Bot.
		if (!socketMessage.Author.IsBot)
		{
			var authorId = socketMessage.Author.Id;
			var channelId  = socketMessage.Channel.Id.ToString();
			var messageId = socketMessage.Id.ToString();
			var message = socketMessage.Content;
			var channel = Client.GetChannel(Convert.ToUInt64(channelId));
			var socketChannel = (ISocketMessageChannel)channel;
			//Do Something and send a response here.
			socketChannel.SendMessageAsync("YOUR RESPONSE");
		}
	});
}
