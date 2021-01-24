public class SignalRConnectionInfo
{
    [JsonProperty(PropertyName = "url")]
    public string Url { get; set; }
    [JsonProperty(PropertyName = "accessToken")]
    public string AccessToken { get; set; }
}
I also created a method inside my `SignalRService` to handle the interaction with the web API's "/negotiate" endpoint in Azure, the instantiation of the hub connection, and the use of an event + delegate for receiving messages as follows:
### SignalRClient.cs
public async Task InitializeAsync()
{
    SignalRConnectionInfo signalRConnectionInfo;
    signalRConnectionInfo = await functionsClient.GetDataAsync<SignalRConnectionInfo>(FunctionsClientConstants.SignalR);
    hubConnection = new HubConnectionBuilder()
        .WithUrl(signalRConnectionInfo.Url, options =>
        {
           options.AccessTokenProvider = () => Task.FromResult(signalRConnectionInfo.AccessToken);
        })
        .Build();
}
The `functionsClient` is simply a strongly typed `HttpClient` pre-configured with a base URL and the `FunctionsClientConstants.SignalR` is a static class with the "/negotiate" path which is appended to the base URL.
Once I had this all set up I called the `await hubConnection.StartAsync();` and it "connected"!
After all this I set up a static `ReceiveMessage` event and a delegate as follows (in the same `SignalRClient.cs`):
public delegate void ReceiveMessage(string message);
public static event ReceiveMessage ReceiveMessageEvent;
Lastly, I implemented the `ReceiveMessage` delegate:
await signalRClient.InitializeAsync(); //<---called from another method
private async Task StartReceiving()
{
    SignalRStatus = await signalRClient.ReceiveReservationResponse(Response.ReservationId);
    logger.LogInformation($"SignalR Status is: {SignalRStatus}");
    // Register event handler for static delegate
    SignalRClient.ReceiveMessageEvent += signalRClient_receiveMessageEvent;
}
private async void signalRClient_receiveMessageEvent(string response)
{
    logger.LogInformation($"Received SignalR mesage: {response}");
    signalRReservationResponse = JsonConvert.DeserializeObject<SignalRReservationResponse>(response);
    await InvokeAsync(StateHasChanged); //<---used by Blazor (server-side)
}
I've provided documentation updates back to the Azure SignalR Service team and sure hope this helps someone else!
  [1]: https://github.com/aspnet/AzureSignalR-samples/blob/master/samples/Serverless/ClientHandler.cs#L25
  [2]: https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-signalr-service#using-signalr-service-with-azure-functions
