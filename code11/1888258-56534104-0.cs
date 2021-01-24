	var actionTypes = new List<string>
	{
		ActionTypes.ImBack,
		ActionTypes.PostBack,
		ActionTypes.MessageBack,
	};
	var cardActions = actionTypes.Select(actionType => new CardAction(
		actionType,
		$"{actionType} title",
		null,
		$"{actionType} value",
		$"{actionType} text",
		$"{actionType} displayText"
	)).ToList();
	var reply = activity.CreateReply("Reply:");
	reply.Attachments = new List<Attachment> { new Attachment(HeroCard.ContentType, content: new HeroCard("Hero title", "Hero subtitle", "Hero text", buttons: cardActions)) };
	reply.SuggestedActions = new SuggestedActions(new List<string> { activity.From.Id }, cardActions);
	await turnContext.SendActivityAsync(reply);
