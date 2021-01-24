    private async Task SendFile(ITurnContext turnContext)
    {
        var webRoot = _env.ContentRootPath;
        var imagePath = System.IO.Path.Combine(webRoot, "Resources", "BotFrameworkDiagram.png");
        var connector = turnContext.TurnState.GetValueOrDefault("Microsoft.Bot.Connector.IConnectorClient") as ConnectorClient;
    
        var attachments = new Attachments(connector);
        var response = await attachments.Client.Conversations.UploadAttachmentAsync(
            turnContext.Activity.Conversation.Id,
            new AttachmentData
            {
                Name = "Results.csv",
                OriginalBase64 = File.ReadAllBytes(imagePath),
                Type = "text/csv"
            });
    
        var attachmentUri = attachments.GetAttachmentUri(response.Id);
    
        var attachment = new Attachment
        {
            Name = "BotFrameworkDiagram.png",
            ContentType = "image/png",
            ContentUrl = attachmentUri
        };
    
        var reply = turnContext.Activity.CreateReply();
        reply.Attachments.Add(attachment);
        await turnContext.SendActivityAsync(reply);   
    }
