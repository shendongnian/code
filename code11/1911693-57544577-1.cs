        public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        { 
            await base.OnTurnAsync(turnContext, cancellationToken);
            var topDispatch = turnContext.TurnState.Get<string>("topDispatch");
            var dispatchRecognizerResult = turnContext.TurnState.Get<RecognizerResult>("dispatchRecognizerResult");
            var dc = await Dialogs.CreateContextAsync(turnContext, cancellationToken);
            var dialogResult = await dc.ContinueDialogAsync();
            if (!dc.Context.Responded)
            {
                switch (dialogResult.Status)
                {
                    case DialogTurnStatus.Empty:
                        await DispatchToTopIntentAsync(turnContext, topDispatch, dispatchRecognizerResult, cancellationToken);
                        break;
                    case DialogTurnStatus.Waiting:
                        break;
                    case DialogTurnStatus.Complete:
                        await dc.EndDialogAsync();
                        break;
                    default:
                        await dc.CancelAllDialogsAsync();
                        break;
                }
            }
            // Save any state changes that might have occured during the turn.
            await ConversationState.SaveChangesAsync(turnContext, false, cancellationToken);
            await UserState.SaveChangesAsync(turnContext, false, cancellationToken);
        }
