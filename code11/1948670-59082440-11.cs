        namespace EchoBot.Dialogs
    {
        public class SecondDialog : ComponentDialog
        {
            private readonly BotStateService _botStateService;
    
            public SecondDialog(string dialogId, BotStateService botStateService) : base(dialogId) 
            {
                _botStateService = botStateService ?? throw new ArgumentNullException(nameof(botStateService));
    
                InitializeWaterfallDialog();
            }
    
            private void InitializeWaterfallDialog()
            {
                var waterfallSteps = new WaterfallStep[]
                {
                    InitialStepAsync,
                    FinalStepAsync
                };
    
                AddDialog(new WaterfallDialog($"{nameof(SecondDialog)}.mainFlow", waterfallSteps));
                AddDialog(new TextPrompt($"{nameof(SecondDialog)}.name"));
    
    
                InitialDialogId = $"{nameof(SecondDialog)}.mainFlow";
            }
    
            private async Task<DialogTurnResult> InitialStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
            {
                    return await stepContext.PromptAsync($"{nameof(SecondDialog)}.name",
                        new PromptOptions
                        {
                            Prompt = MessageFactory.Text("Please enter your Name.")
                        }, cancellationToken);
            }
    
            private async Task<DialogTurnResult> FinalStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
            {
    
                //Suppose you want to call First Dialog from here
                return await stepContext.BeginDialogAsync($"{nameof(SecondDialog)}.firstFromSecond", null, cancellationToken);
            }
        }
    }
