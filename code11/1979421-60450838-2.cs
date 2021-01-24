    public class DialogBot<T> : ActivityHandler
        where T : Dialog
    {
        protected readonly DialogSet Dialogs;
        protected readonly BotState ConversationState;
        protected readonly BotState UserState;
        protected readonly ILogger Logger;
        public DialogBot(ConversationState conversationState, UserState userState, IEnumerable<Dialog> dialogs, ILogger<DialogBot<T>> logger)
        {
            ConversationState = conversationState;
            UserState = userState;
            Logger = logger;
            Dialogs = new DialogSet(conversationState.CreateProperty<DialogState>(nameof(DialogState)));
            foreach(var dialog in dialogs)
            {
                Dialogs.Add(dialog);
            }
        }
        public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            await base.OnTurnAsync(turnContext, cancellationToken);
            // Save any state changes that might have occured during the turn.
            await ConversationState.SaveChangesAsync(turnContext, false, cancellationToken);
            await UserState.SaveChangesAsync(turnContext, false, cancellationToken);
        }
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            Logger.LogInformation("Running dialog with Message Activity.");
            var dc = await Dialogs.CreateContextAsync(turnContext, cancellationToken).ConfigureAwait(false);
            if (dc.ActiveDialog != null)
            {
                await dc.ContinueDialogAsync();
            }
            else
            {
                // Run the Dialog with the new message Activity.
                await dc.BeginDialogAsync(typeof(T).Name, ConversationState.CreateProperty<DialogState>("DialogState"), cancellationToken);
            }
        }
    }
