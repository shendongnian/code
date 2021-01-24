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
    if (activity.Type == ActivityTypes.Message)
    {
        // Ensure that message is a postBack (like a submission from Adaptive Cards)
        if (dc.Context.Activity.GetType().GetProperty("ChannelData") != null) {
            var channelData = JObject.Parse(dc.Context.Activity.ChannelData.ToString());
            if (channelData.ContainsKey("postBack"))
            {
                var postbackActivity = dc.Context.Activity;
                // Convert the user's Adaptive Card input into the input of a Text Prompt
                // Must be sent as a string
                postbackActivity.Text = postbackActivity.Value.ToString();
                await dc.Context.SendActivityAsync(postbackActivity);
            }
        }            
    }
Again, read the linked answers for more details.
