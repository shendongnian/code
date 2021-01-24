if (dc.Context.Activity.Type == ActivityTypes.Message)
{
    //PropertyInfo channelDataProperty = dc.Context.Activity.GetType().GetProperty("ChannelData");
    Activity activity = dc.Context.Activity;
    object rawChannelData = activity.ChannelData;
    // For the Bot Framework Emulator
    if (rawChannelData != null)
    {
        JObject channelData = JObject.Parse(rawChannelData.ToString());
        if (channelData.Children().Any(c => ((JProperty)c).Name == "postBack") && activity.Value != null)
        {
            dc.Context.Activity.Text = "your-value-here";
        }
    }
    // For the WebChat channel since it doesn't provide ChannelData
    else if (activity.ChannelId == Channels.Webchat && activity.Value != null)
    {
        dc.Context.Activity.Text = "your-value-here";
    }
}
This could be further simplified (if you like) to:
if (dc.Context.Activity.Type == ActivityTypes.Message)
{
    // For the Bot Framework Emulator AND the WebChat channel
    if (dc.Context.Activity.Value != null && dc.Context.Activity.Text == null)
    {
        dc.Context.Activity.Text = "your-value-here";
    }
}
The reason that the simplified version of code above _should_ work is because as you know Adaptive Cards are the only time that the `.Value` property of the `Activity` should be populated, the rest of the time the postback data is in the `.Text` property and it will be automatically picked up by the code in your WaterfallDialog. I would advise testing this simplified code yourself before deciding to go with it as you may have scenarios that I do not where `.Value` is populated outside of an Adaptive Card.
