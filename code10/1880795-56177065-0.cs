private static async Task<DialogTurnResult> ShowCardStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
{
 var getFeedback = stepContext.Context.Activity.CreateReply();
        var feedbackChoices = new HeroCard
        {
            Text = "Our conversation was helpful?",
            Buttons = new List<CardAction>
            {
                new CardAction() { Title = Constants.userResponseThumbsUp, Type = ActionTypes.ImBack, Value = Constants.userResponseYes},
                new CardAction() { Title = Constants.userResponseThumbsDown, Type = ActionTypes.ImBack, Value = Constants.userResponseNo},
            },
        };
        // Add the card to our reply to user.
        getFeedback.Attachments = new List<Attachment>() { feedbackChoices.ToAttachment() };
        await stepContext.Context.SendActivityAsync(getFeedback, cancellationToken);
}
Hope this helps.
