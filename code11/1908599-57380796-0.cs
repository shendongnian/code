AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
            {
                PromptStepAsync,
                LoginStepAsync,
                DisplayTokenPhase1Async,
                DisplayTokenPhase2Async,
            }));
            // The initial child Dialog to run.
            InitialDialogId = nameof(WaterfallDialog);
        }
        private async Task<DialogTurnResult> PromptStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await stepContext.BeginDialogAsync(nameof(OAuthPrompt), null, cancellationToken);
        }
private async Task<DialogTurnResult> LoginStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            // Get the token from the previous step. Note that we could also have gotten the
            // token directly from the prompt itself. There is an example of this in the next method.
            var tokenResponse = (TokenResponse)stepContext.Result;
            if (tokenResponse != null)
            {
                await stepContext.Context.SendActivityAsync(MessageFactory.Text("You are now logged in."), cancellationToken);
                return await stepContext.PromptAsync(nameof(ConfirmPrompt), new PromptOptions { Prompt = MessageFactory.Text("Would you like to view your token?") }, cancellationToken);
            }
            await stepContext.Context.SendActivityAsync(MessageFactory.Text("Login was not successful please try again."), cancellationToken);
            return await stepContext.EndDialogAsync(cancellationToken: cancellationToken);
        }
As you can see from these two steps, it prompts, then it checks. If the check fails, it ends the dialog, which means when the bot is messaged again, the waterfall simply starts over. This continues until a token is returned, then it moves on to the 'would you like to see your token' prompt. Clearly you're not going to be asking your customers if they'd like to see their tokens, but the idea is solid.
case LUISIntent.FindRoom:
//TINY WATERFALL HERE
//this waterfall would be added to your dialogs wherever you add them. 
//for the sake of brevity, i'm skipping that part
//WATERFALL STEP 1:
private async Task<DialogTurnResults> GETTINGYOURLOGIN(WaterfallStepContext stepContext, CancellationToken cancellationToken)
{
    token = await _authToken.GetAsync(turnContext, () => token);
    return await stepContext.NextAsync(cancellationToken);
}
//WATERFALL STEP 2:
private async Task<DialogTurnResults> CHECKINGYOURLOGIN(WaterfallStepContext stepContext, CancellationToken cancellationToken)
{
// Get the token from the previous step.
//this does a quick check to see if it's NOT null, then goes to the next step.
//OTHERWISE, it continues with your login prompt.
//this way, if your user has ALREADY logged in, and for whatever reason goes BACK to the //book room dialog, they don't have to re-login if it's been a short enough time
if (!token.IsNullOrWhiteSpace())
{
   await dc.BeginDialogAsync(nameof(FindRoom), luisResults);
}
var resultToken = dc.BeginDialogAsync(nameof(SignInDialog),
            cancellationToken: cancellationToken);
        
if (resultToken.Status != TaskStatus.WaitingForActivation)
{
    var tokenResponse = resultToken.Result;
    var tokenResult = (TokenResponse)tokenResponse.Result;
    token = tokenResult.Token;
    await _authToken.SetAsync(turnContext, token, cancellationToken);
}
// Replace on the stack the current instance of the waterfall with a new instance,
// and start from the top.
return await stepContext.ReplaceDialogAsync(nameof(YOURMINIWATERFALLDIALOG), cancellationToken: cancellationToken);
    
}
This is really rough, but it should be enough to give you a general idea of what I mean. By dropping that continuation that you say is failing into it's own if-check that's dependent on the token, you'll be prevented from moving on without a valid one, and thus failing. 
