    private async Task<DialogTurnResult> UploadAttachmentAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            stepContext.Values["desc"] = (string)stepContext.Result;
         //   if ((bool)stepContext.Result)
            {
                return await stepContext.PromptAsync(
            attachmentPromptId,
            new PromptOptions
            {
                Prompt = MessageFactory.Text($"Can you upload a file?"),
            });
            }
            //else
            //{
            //    return await stepContext.NextAsync(-1, cancellationToken);
            //}
            
        }
