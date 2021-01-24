    private static async Task<DialogTurnResult> PromptForLocation(WaterfallStepContext stepContext, CancellationToken cancellationToken)
    {
        Activity reply = stepContext.Context.Activity.CreateReply();
        reply.Text = "What is your location?";
        reply.ChannelData = JObject.FromObject( new {
            
            quick_replies = new object[]
            {
                new
                {
                    content_type = "location",
                },
            },
        });
        return await stepContext.PromptAsync("location", new PromptOptions { Prompt = reply }, cancellationToken);
    }
