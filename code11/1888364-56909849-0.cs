    foreach (var a in activities)
    {
    	incrementId++;
    	// Use your own ID format
    	a.Id = string.Concat("history|", incrementId.ToString().PadLeft(7, '0'));
    	a.ChannelData = null;
    	a.Conversation = new ConversationAccount(id: convId);
    
    	if (a.From.Name == message.Recipient.Name)
    	{
    		// If the activity was from the bot, assign the user as the recipient
    		a.Recipient = message.From;
    	}
    	else
    	{
    		// If the activity was from the user, assign the bot as the recipient
    		a.Recipient = message.Recipient;
    	}
    }
