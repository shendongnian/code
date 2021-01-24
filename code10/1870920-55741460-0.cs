            if (activity.Value != null) // Handle action.
            {
                Activity replyMessage = activity.CreateReply("You can select max 2 nos");
                await connector.Conversations.ReplyToActivityAsync(replyMessage);
                return;
            }
            AdaptiveCard adaptiveCard = new AdaptiveCard("1.0");
            adaptiveCard.Body.Add(new AdaptiveTextInput()
            {
                Id = "Test",
                Placeholder = "enter your name here",
            });
            adaptiveCard.Actions = new System.Collections.Generic.List<AdaptiveAction>()
            {
                new AdaptiveSubmitAction()
                {
                    Id = "testSubmit",
                }
            };
            Attachment attachment = new Attachment
            {
                ContentType = AdaptiveCards.AdaptiveCard.ContentType,
                Content = adaptiveCard
            };
            var reply = activity.CreateReply();
            reply.Attachments.Add(attachment);
            await connector.Conversations.ReplyToActivityAsync(reply);
