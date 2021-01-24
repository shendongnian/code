    protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
                {
        var reply = new Activity(); //this line caused the error
        ……..
        
        }
