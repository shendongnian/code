    private async Task BotCallback(ITurnContext turnContext, CancellationToken cancellationToken)
            {
                try
                {
                    var conversationStateAccessors = _ConversationState.CreateProperty<DialogState>(nameof(DialogState));
    
                    var dialogSet = new DialogSet(conversationStateAccessors);
                    dialogSet.Add(this._Dialog);
    
                    var dialogContext = await dialogSet.CreateContextAsync(turnContext, cancellationToken);
                    var results = await dialogContext.ContinueDialogAsync(cancellationToken);
                    if (results.Status == DialogTurnStatus.Empty)
                    {
                        await dialogContext.BeginDialogAsync(_Dialog.Id, null, cancellationToken);
                        await _ConversationState.SaveChangesAsync(dialogContext.Context, false, cancellationToken);
                    }
                    else
                        await turnContext.SendActivityAsync("Starting proactive message bot call back");
                }
                catch (Exception ex)
                {
                    this._Logger.LogError(ex.Message);
                }
            }
