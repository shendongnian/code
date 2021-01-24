	if (string.IsNullOrEmpty(turnContext.Activity.Text))
	{
		dynamic value = turnContext.Activity.Value;
		string text = value["text"];   // The property will be named after your input's ID
		var emailRegex = new Regex(@"^\S+@\S+$");   // This is VERY basic email Regex. You might want something different.
		if (emailRegex.IsMatch(text))
		{
			await turnContext.SendActivityAsync($"I think {text} is a valid email address");
		}
		else
		{
			await turnContext.SendActivityAsync($"I don't think {text} is a valid email address");
		}
	}
