        connector = new ConnectorClient(new Uri(activity.ServiceUrl));
        reply = activity.CreateReply();
        reply.Attachments.Add(Card.ToAttachment());
        var msgToUpdate = await connector.Conversations.ReplyToActivityAsync(reply);
        // Keep mapping of uniqueId and messageToUpdate.Id
        // UniqueId1 => messageId1
        // UniqueId2 => messageId2
