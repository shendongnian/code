c#
string subscriptionEntityPath = "my-topic/subscriptions/my-subscription";
MessageReceiver receiver = new MessageReceiver(
    serviceBusConnectionString,
    subscriptionEntityPath,
    ReceiveMode.PeekLock);
var message = await receiver.ReceiveAsync(TimeSpan.FromSeconds(5));
while (message != null)
{
    // handle message
    message = await receiver.ReceiveAsync(TimeSpan.FromSeconds(5));
}
await receiver.CloseAsync();
