    else if (stepContext.Context.Activity.Text == "Others")
        {
            var attachments = new List<Attachment>();
            var reply = MessageFactory.Attachment(attachments);
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            reply.Attachments.Add(Cards.GetHeroCard5().ToAttachment());
            await stepContext.Context.SendActivityAsync(reply, cancellationToken);
            await stepContext.Context.SendActivityAsync(MessageFactory.Text("I will be here if you need me further."), cancellationToken);
            return await stepContext.EndDialogAsync(null, cancellationToken);
        }
