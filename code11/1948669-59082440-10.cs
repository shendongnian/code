        namespace EchoBot.Dialogs
    {
        public class FirstDialog : ComponentDialog
        {
            private readonly BotStateService _botStateService;
    
            public FirstDialog(string dialogId, BotStateService botStateService) : base(dialogId)
            {
                _botStateService = botStateService ?? throw new ArgumentNullException(nameof(botStateService));
                if (dialogId == $"{ nameof(MainDialog)}.first")
                    InitializeWaterfallDialog1();
                else
                    InitializeWaterfallDialog2();
            }
    
            private void InitializeWaterfallDialog1()
            {
                var waterfallsteps = new WaterfallStep[]
                {
                    GetAge,
                    GetCity,
                    FinalStepAsync
                };
                AddDialog(new WaterfallDialog($"{nameof(FirstDialog)}.mainFlow", waterfallsteps));
                AddDialog(new NumberPrompt<int>($"{nameof(FirstDialog)}.age"));
                AddDialog(new TextPrompt($"{nameof(FirstDialog)}.city"));
    
                InitialDialogId = $"{nameof(FirstDialog)}.mainFlow";
            }
            private void InitializeWaterfallDialog2()
            {
                var waterfallsteps = new WaterfallStep[]
                {
                    GetCity,
                    FinalStepAsync
                };
                AddDialog(new WaterfallDialog($"{nameof(FirstDialog)}.mainFlow", waterfallsteps));
                AddDialog(new NumberPrompt<int>($"{nameof(FirstDialog)}.age"));
                AddDialog(new TextPrompt($"{nameof(FirstDialog)}.city"));
    
                InitialDialogId = $"{nameof(FirstDialog)}.mainFlow";
            }
    
            private async Task<DialogTurnResult> GetAge(WaterfallStepContext stepContext, CancellationToken cancellationToken)
            {
                return await stepContext.PromptAsync($"{nameof(FirstDialog)}.age",
                    new PromptOptions
                    {
                        Prompt = MessageFactory.Text("Please enter your age."),
                        RetryPrompt = MessageFactory.Text("Please enter a valid age.")
                    }, cancellationToken);
            }
    
            private async Task<DialogTurnResult> GetCity(WaterfallStepContext stepContext, CancellationToken cancellationToken)
            {
                return await stepContext.PromptAsync($"{nameof(FirstDialog)}.age",
                     new PromptOptions
                     {
                         Prompt = MessageFactory.Text("Please enter your city."),
                         RetryPrompt = MessageFactory.Text("Please enter a valid city.")
                     }, cancellationToken);
            }
    
            private async Task<DialogTurnResult> FinalStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
            {
                return await stepContext.EndDialogAsync(null, cancellationToken);
            }
        }}
