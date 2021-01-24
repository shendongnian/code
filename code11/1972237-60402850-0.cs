csharp
[FunctionName("ProcessEvents")]
public static async Task ProcessEvents(
    [EventHubTrigger("event-source")] EventData input,
    [DurableClient] IDurableClient client)
{
    if (IsOfInterest(input))
    {
        var id = new EntityId("MyDetector", (string)input.Properties["ID"]);
        await client.SignalEntityAsync(id, nameof(MyDetector.Process), input);
    }
    // ...
}
...and here is the entity function (implemented as a [.NET class](https://docs.microsoft.com/en-us/azure/azure-functions/durable/durable-functions-dotnet-entities#defining-entity-classes)):
csharp
[JsonObject(MemberSerialization.OptIn)]
public class MyDetector
{
    [JsonProperty]
    public int CurrentEventCount { get; set; }
    public void Process(EventData input) 
    {
        // Take some action if this event happens N or more times
        if (++this.CurrentEventCount >= 10)
        {
            TakeSomeAction(input);
            // reset the counter
            this.CurrentEventCount = 0;
        }
    }
    [FunctionName(nameof(MyDetector))]
    public static Task Run([EntityTrigger] IDurableEntityContext ctx)
        => ctx.DispatchAsync<MyDetector>();
}
