var feedback = ((Activity)context.Activity).CreateReply("Did you find what you need?");
feedback.SuggestedActions = new SuggestedActions()
{
    Actions = new List<CardAction>()
    {
        new CardAction(){ Title = "Yes", Type=ActionTypes.PostBack, Value=$"yes-positive-feedback" },
        new CardAction(){ Title = "No", Type=ActionTypes.PostBack, Value=$"no-negative-feedback" }
    }
};
await context.PostAsync(feedback);
