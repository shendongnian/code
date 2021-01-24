    public async Task SendSms(string messageText, string recipient)
    {
    	var message = new SmsMessage(messageText, new []{ recipient });
    	await Sms.ComposeAsync(message);
    }
