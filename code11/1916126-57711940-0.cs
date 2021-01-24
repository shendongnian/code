     public class YourDialog : ComponentDialog
     {
            private readonly IStatePropertyAccessor<UserStateClass> _userStateclassAccessor;
 
            public YourDialog(UserState userState)
                : base(nameof(YourDialog))
            {
                _userProfileAccessor = userState.CreateProperty<UserStateClass>("UserProfile");
    
                WaterfallStep[] waterfallSteps = new WaterfallStep[]
                {
                    FirstStepAsync,
                };
                AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallSteps));
            }
    
            private async Task<DialogTurnResult> FirstStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
            {
                var userstate = await _userStateclassAccessor.GetAsync(stepContext.Context, () => new UserStateClass(), cancellationToken);
    
    	        userstate.name = "pepe";
    	        return await stepContext.EndDialogAsync();
            }
     }
