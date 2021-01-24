`
public static void Run([QueueTrigger("signalr-messages", Connection = "Azure.Storage.Main")]string myQueueItem, ILogger log)
{
    <Deserialise>
    SendMessage(message, null);
}
`
My SendMessage function looks like;
`
public static Task SendMessage(Message message, [SignalR(HubName = "baseHub")]IAsyncCollector<SignalRMessage> signalRMessages)
{
    return signalRMessages.AddAsync(
    new SignalRMessage
      {
        Target = "sendMessage",
        Arguments = new[] { message }
      });
}
`
I'm passing "null" in SendMessage however I know this is wrong - The examples I can find come from HTTP Triggers and not Queue Triggers
Am I even going down the right path with this?
