var postbackActivity = dc.Context.Activity;
string text = JsonConvert.DeserializeObject<DialogValueDto>(postbackActivity.Value.ToString())?.UserInput;
postbackActivity.Text = text;
await dc.Context.SendActivityAsync(postbackActivity);
I was setting the `Text` property of `postBackActivity` variable instead of directly setting the `Text` property directly on `dc.Context.Activity`. Because I was sending the the variable through `SendActivityAsync` it was covering up this mistake because I was getting the value I wanted passed through to the `OnEventAsync` method in my `MainDialog` class.
The correct way was to set this directly on the context, not on a copy of it (DOH!)
dc.Context.Activity.Text = text
---
2) Inside the `OnEventAsync` method in my `MainDialog` class I had an empty block which caught the response but did nothing with it (it needed to call `await dc.ContinueDialogAsync()`). However, this was already handled by an existing block of code in the Virtual Assistant template which my empty block was preventing from being hit. 
object value = dc.Context.Activity.Value;
if (condition)
{
    // do nothing
}
else if (value.GetType() == typeof(JObject))
{
    // code from the Virtual Assistant template to check the values passed through
    var submit = JObject.Parse(value.ToString());
    // more template code
    // Template code
    if (forward)
    {
        var result = await dc.ContinueDialogAsync();
		if (result.Status == DialogTurnStatus.Complete)
		{
			await CompleteAsync(dc);
		}
    }
}
Once I removed my empty `if` block then it fell through to the code it needed (the forward part).
---
Change list:
DynamicWaterfallDialog:
public DynamicWaterfallDialog(
    ...
    )
    : base(nameof(DynamicWaterfallDialog))
{
    ...
    InitialDialogId = nameof(WaterfallDialog);
    var waterfallSteps = new WaterfallStep[]
    {
        UserInputStepAsync,
        LoopStepAsync,
    };
    AddDialog(new TextPrompt(nameof(TextPrompt)));
    AddDialog(new WaterfallDialog(InitialDialogId, waterfallSteps));
}
DialogBot:
public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken)
{
    ...
    
    var dc = await _dialogs.CreateContextAsync(turnContext);
    if (dc.Context.Activity.Type == ActivityTypes.Message)
    {
        // Ensure that message is a postBack (like a submission from Adaptive Cards)
        if (dc.Context.Activity.GetType().GetProperty("ChannelData") != null)
        {
            JObject channelData = JObject.Parse(dc.Context.Activity.ChannelData.ToString());
            Activity postbackActivity = dc.Context.Activity;
            if (channelData.ContainsKey("postBack") && postbackActivity.Value != null)
            {
                DialogValueDto dialogValueDto = JsonConvert.DeserializeObject<DialogValueDto>(postbackActivity.Value.ToString());
                // Only set the text property for adaptive cards because the value we want, and the value that the user submits comes through the
                // on the Value property for adaptive cards, instead of the text property like everything else
                if (DialogValueDtoExtensions.IsValidDialogValueDto(dialogValueDto) && dialogValueDto.CardType == CardTypeEnum.Adaptive)
                {
                    // Convert the user's Adaptive Card input into the input of a Text Prompt, must be sent as a string
                    dc.Context.Activity.Text = JsonConvert.SerializeObject(dialogValueDto);
                    // We don't need to post the text as per https://stackoverflow.com/a/56010355/5209435 because this is automatically handled inside the
                    // OnEventAsync method of MainDialog.cs
                }
            }
        }
    }
    if (dc.ActiveDialog != null)
    {
        var result = await dc.ContinueDialogAsync();
    }
    else
    {
        await dc.BeginDialogAsync(typeof(T).Name);
    }
}
MainDialog:
protected override async Task OnEventAsync(DialogContext dc, CancellationToken cancellationToken = default(CancellationToken))
{
    object value = dc.Context.Activity.Value;
    if (value.GetType() == typeof(JObject))
    {
        var submit = JObject.Parse(value.ToString());
        if (value != null)
        {
            // Null propagation here is to handle things like dynamic adaptive cards that submit objects
            string action = submit["action"]?.ToString();
            ...
        }
        var forward = true;
        var ev = dc.Context.Activity.AsEventActivity();
        // Null propagation here is to handle things like dynamic adaptive cards that may not convert into an EventActivity
        if (!string.IsNullOrWhiteSpace(ev?.Name))
        {
            ...
        }
        if (forward)
        {
            var result = await dc.ContinueDialogAsync();
            if (result.Status == DialogTurnStatus.Complete)
            {
                await CompleteAsync(dc);
            }
        }
    }
}
I guess I was expecting having the Text property set on the context to automatically fire through to my `LoopStepAsync` (DynamicWaterfallDialog) handler rather than falling into OnEventAsync (MainDialog). I knew I needed to call `ContinueDialogAsync` somewhere and should have been more suspicious of the final paragraph of my question:
> Interestingly enough my OnEventAsync function of my MainDialog (the one which is wired up in Startup.cs via services.AddTransient<IBot, DialogBot<MainDialog>>();) gets fired when I set the text property of the activity.
So close, yet so far. Hopefully this helps someone else out in the future. 
Link that I found helpful were:
* [ComplexDialogBot.cs](https://github.com/Microsoft/BotFramework-Samples/blob/master/SDKV4-Samples/dotnet_core/ComplexDialogBot/ComplexDialogBot.cs).
* [Question about adaptive cards and waterfalls](https://stackoverflow.com/questions/56004289/botframework-how-to-capture-extract-the-values-submitted-through-adaptive-car/56010355#56010355).
* [GitHub issue about Adaptive Cards and prompts](https://github.com/Microsoft/botbuilder-dotnet/issues/614#issuecomment-443946026).
