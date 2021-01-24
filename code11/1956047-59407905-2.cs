cs
 if (Enum.TryParse(setting.Name, true, out eventType)) 
     return eventType;
 else
     return ConsumedEventType.NotSpecified;
You can parse the string with setting name to event type, use the parsed value, otherwise return `NotSpecified` value. It's more easy, than maintain a list of values. In terms of your code above you can write something like that
cs
foreach (var setting in consumerSettingsSection.QueueSettings)
{
    var eventType = ConsumedEventType.NotSpecified;
    if (Enum.TryParse(setting.Name, true, out ConsumedEventType parsedEvent))
    {
         eventType = parsedEvent;
    }
    //rest of code
}
Or even easier
cs
if (!Enum.TryParse(setting.Name, true, out ConsumedEventType eventType))
{
    eventType = ConsumedEventType.NotSpecified;
}
Inline `out` variables are supported from C# 7
