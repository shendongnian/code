const string ISO8601Format = "yyyy-MM-dd";
string text = "dynamic-text-here;
DateTime today = DateTime.Today;
string todayAsIso = today.ToString(ISO8601Format);
// Create card
AdaptiveCard adaptiveCard = new AdaptiveCard("1.0")
{
    Body =
    {
        new AdaptiveContainer
        {
            Items =
            {
                new AdaptiveTextBlock
                {
                    Text = question,
                    Wrap = true
                },
                new AdaptiveDateInput
                {
                    // This Id matches the property in DialogValueDto so it will automatically be set
                    Id = "UserInput",
                    Value = todayAsIso,
                    Min = today.AddDays(-7).ToString(ISO8601Format),
                    Max = todayAsIso,
                    Placeholder = todayAsIso
                }
            }
        }
    },
    Actions = new List<AdaptiveAction>
    {
        new AdaptiveSubmitAction
        {
            // Data can be an object but this will require the value provided for the 
            // Content property to be serialised it to a string
            // as per this answer https://stackoverflow.com/a/56297792/5209435
            // See the attachment block below for how this is handled
            Data = "your-submit-data",
            Title = "Confirm",
            Type = "Action.Submit"
        }
    }
};
// Create message attachment
Attachment attachment = new Attachment
{
    ContentType = AdaptiveCard.ContentType,
    // Trick to get Adapative Cards to work with prompts as per https://github.com/Microsoft/botbuilder-dotnet/issues/614#issuecomment-443549810
    Content = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(adaptiveCard))
};
cardActivity.Attachments.Add(attachment);
// Send the message
context.SendActivityAsync(cardActivity);
Because `Items` and `Actions` are collections, you could have conditional logic inside your code to build up these collections based on some condition at runtime then pass the build collection to `Items` or `Actions` which will allow you more flexibility than having a JSON template that you replace placeholder tokens at a known location.
