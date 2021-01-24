//FIRST
AddDialog(new ConfirmPrompt(nameof(ConfirmPrompt)));
AddDialog(new WaterfallDialog(nameof(STARTSKILLB), new WaterfallStep[]
{
    AskStepAsync,
    LoopStepAsync
}));
//LATER, ON CHECKING INTENTS
switch(intent)
{
    case "SkillA":
        await KEEPONSKILLA(turnContext, cancellationToken);
        break;
    case "SkillB":
        await stepContext.BeginDialogAsync(nameof(STARTSKILLB), cancellationToken);
        break;
}
//THEN THIS
private async Task<DialogTurnResult> AskStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
{
    var messageText = $"Would you like to go chill in Skill B?";
    var promptMessage = MessageFactory.Text(messageText, messageText, InputHints.ExpectingInput);
    return await stepContext.PromptAsync(nameof(ConfirmPrompt), new PromptOptions { Prompt = promptMessage }, cancellationToken);
    }
}
private async Task<DialogTurnResult> LoopStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
{
    if ((bool)stepContext.Result)
    {
        //shift on over to skill  B
    }
    //End this dialog, routing back up to where you left off in Skill A
    return await stepContext.EndDialogAsync(null, cancellationToken);
}
