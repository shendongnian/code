csharp
private async Task<DialogTurnResult> DisplayCardAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
    {
        // Display the Adaptive Card
        var message = MessageFactory.Text("");
        message.Attachments = new List<Attachment>() { yourCard };
        await stepContext.Context.SendActivityAsync(message, cancellationToken);
        // Create the text prompt
        var opts = new PromptOptions
        {
            Prompt = new Activity
            {
                Type = ActivityTypes.Message,
                Text = "waiting for user input...", // You can comment this out if you don't want to display any text. Still works.
            }
        };
        // Display a Text Prompt and wait for input
        return await stepContext.PromptAsync(nameof(TextPrompt), opts);
    }
    private async Task<DialogTurnResult> HandleResponseAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
    {
        // Do something with step.result
        // Adaptive Card submissions are objects, so you likely need to JObject.Parse(step.result)
        await stepContext.Context.SendActivityAsync($"INPUT: {stepContext.Result}");
        return await stepContext.NextAsync();
    }
and
csharp
var activity = turnContext.Activity;
if (string.IsNullOrWhiteSpace(activity.Text) && !string.IsNullOrWhiteSpace(activity.Value))
{
	activity.Text = JsonConvert.SerializeObject(activity.Value);
}
Again, read the linked answers for more details.
