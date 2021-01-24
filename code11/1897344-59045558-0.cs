        protected override async Task OnConversationUpdateActivityAsync(ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            await base.OnConversationUpdateActivityAsync(turnContext, cancellationToken);
            if (turnContext.Activity.ChannelId == "webchat" && turnContext.Activity.MembersAdded?.FirstOrDefault(m => m?.Name == Configuration["BotName"]) != null)
            {
                await SendWelcomeMessageAsync(turnContext, cancellationToken);
            }
        }
