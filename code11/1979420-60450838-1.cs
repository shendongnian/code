    public class SetupDialog : ComponentDialog
    {
        public SetupDialog()
            : base(nameof(SetupDialog))
        {
            AddDialog(new TextPrompt(nameof(TextPrompt)));
        }
        public override Task<DialogTurnResult> ContinueDialogAsync(DialogContext outerDc, CancellationToken cancellationToken = default)
        {
            if (!int.TryParse(outerDc.Context.Activity.Text, out var recursions))
            {
                return outerDc.PromptAsync(nameof(TextPrompt), new PromptOptions()
                {
                    Prompt = MessageFactory.Text($"{outerDc.Context.Activity.Text} konnte nicht in eine Zahl konvertiert werden.")
                });
            }
            return outerDc.EndDialogAsync(recursions);
        }
        public override Task<DialogTurnResult> BeginDialogAsync(DialogContext outerDc, object options = null, CancellationToken cancellationToken = default)
        {
            return base.BeginDialogAsync(outerDc, options, cancellationToken);
        }
        protected override Task<DialogTurnResult> OnBeginDialogAsync(DialogContext innerDc, object options, CancellationToken cancellationToken = default)
        {
            return innerDc.PromptAsync(nameof(TextPrompt), new PromptOptions()
            {
                Prompt = MessageFactory.Text("Wie viel rekursionen sollen erstellt werden?")
            });
        }
    }
