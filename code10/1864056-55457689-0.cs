	if (string.IsNullOrEmpty(message.Text))
	{
		if (message.Attachments[0].Content is HeroCard attachment)
		{
			message.Speak = TextToSpeechHelper.ConvertTextToSpeechText(attachment.Text);
		}
	}
	else
	{
		message.Speak = TextToSpeechHelper.ConvertTextToSpeechText(message.Text);
	}
