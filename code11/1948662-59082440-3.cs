        namespace EchoBot.Dialogs
        {
            public class MainDialog : ComponentDialog
            {
                private readonly BotStateService _botStateService;
        
                public MainDialog(BotStateService botStateService) : base(nameof(MainDialog))
                {
                    _botStateService = botStateService;
        
                    InitializeWaterfallDialog();
                }
        
                private void InitializeWaterfallDialog()
                {
                    var waterfallSteps = new WaterfallStep[]
                    {
                        InitialStepAsync,
                        FinalStepAsync
                    };
        
                    AddDialog(new SecondDialog($"{nameof(MainDialog)}.second", _botStateService));
                    AddDialog(new FirstDialog($"{nameof(MainDialog)}.first", _botStateService)); 
    AddDialog(new FirstDialog($"{nameof(SecondDialog)}.firstFromSecond", _botStateService));
                    AddDialog(new WaterfallDialog($"{nameof(MainDialog)}.mainFlow", waterfallSteps));
        
                    InitialDialogId = $"{nameof(MainDialog)}.mainFlow";
                }
        
                private async Task<DialogTurnResult> InitialStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
                {
                    if (Regex.Match(stepContext.Context.Activity.Text.ToLower(), "hi").Success)
                    {
                        return await stepContext.BeginDialogAsync($"{nameof(MainDialog)}.second", null, cancellationToken);
                    }
                    else
                    {
                        return await stepContext.BeginDialogAsync($"{nameof(MainDialog)}.first", null, cancellationToken);
                    }
                    
                }
                
                private async Task<DialogTurnResult> FinalStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
                {
                   return await stepContext.EndDialogAsync(null,cancellationToken);
                }
            } }
