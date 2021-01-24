public class ScenarioOne : ComponentDialog
{
    private static string textInputId = "text";
    public ScenarioOne()
    {
        var steps = new WaterfallStep[]
        {
            GetInputStepAsync,
            ProcessInputStepAsync
        };
        AddDialog(new WaterfallDialog(nameof(ScenarioOne), steps));
        AddDialog(new TextPrompt(textInputId));
    }
    private async Task<DialogTurnResult> GetInputStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
    {
        // Prompt for data here.
    }
    protected override Task<DialogTurnResult> OnContinueDialogAsync(DialogContext innerDc, CancellationToken cancellationToken = default)
    {
        string text = innerDc.Context.Activity.Text;
        if (text.ToLower() == "help" && innerDc.ActiveDialog.Id != textInputId)
        {
            //do interruption
        }
        return base.OnContinueDialogAsync(innerDc, cancellationToken);
    }
}
