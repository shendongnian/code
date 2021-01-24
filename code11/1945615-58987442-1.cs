    protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
    {
        var imagePath = Path.Combine(Environment.CurrentDirectory, @"Resources\uc2icon.png");
        var imageData = Convert.ToBase64String(File.ReadAllBytes(imagePath));
        var url = $"data:image/png;base64,{imageData}";
        var adaptiveJsonString = "{\"$schema\":\"http://adaptivecards.io/schemas/adaptive-card.json\",\"type\":\"AdaptiveCard\",\"version\":\"1.0\",\"body\":[{\"type\":\"ImageSet\",\"imageSize\":\"auto\",\"images\":[{\"type\":\"Image\",\"url\":\""+ url + "\"}]}]}";
        var adaptiveCardAttachment = new Attachment()
        {
            ContentType = "application/vnd.microsoft.card.adaptive",
            Content = JsonConvert.DeserializeObject(adaptiveJsonString),
        };
        
        await turnContext.SendActivityAsync(MessageFactory.Attachment(adaptiveCardAttachment), cancellationToken);
    }
