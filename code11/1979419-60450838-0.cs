    public class RootDialog : ComponentDialog
    {
        private int recursions;
        public RootDialog(SetupDialog setupDialog)
            : base(nameof(RootDialog))
        {
            AddDialog(setupDialog);
            AddDialog(new TextPrompt(nameof(TextPrompt)));
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
            {
                ProcessStep
            }));
            InitialDialogId = nameof(SetupDialog);
        }
        public async Task<DialogTurnResult> ProcessStep(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions
            {
                Prompt = MessageFactory.Text("Process step in root dialog")
            });
            if(Dialogs.Find(nameof(RecursiveDialog)) == null)
            {
                AddDialog(new RecursiveDialog(new DialogSet(), recursions));
            }
            if (recursions > 0)
            {
                return await stepContext.BeginDialogAsync(nameof(RecursiveDialog));
            }
            return await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions
            {
                Prompt = MessageFactory.Text("Recursion lower or eqaul 0")
            });
        }
        public override async Task<DialogTurnResult> BeginDialogAsync(DialogContext outerDc, object options = null, CancellationToken cancellationToken = default)
        {
            if (true)
            {
                return await outerDc.BeginDialogAsync(nameof(SetupDialog));
            }
            var dialogContext = CreateChildContext(outerDc);
            await dialogContext.PromptAsync(nameof(TextPrompt), new PromptOptions
            {
                Prompt = MessageFactory.Text("Begin root dialog")
            });
            return await base.BeginDialogAsync(outerDc, options, cancellationToken);
        }
        protected override async Task<DialogTurnResult> OnContinueDialogAsync(DialogContext innerDc, CancellationToken cancellationToken = default)
        {
            if(innerDc.ActiveDialog != null)
            {
                return await innerDc.ContinueDialogAsync();
            }
            return await base.OnContinueDialogAsync(innerDc, cancellationToken);
        }
        public override async Task<DialogTurnResult> ResumeDialogAsync(DialogContext outerDc, DialogReason reason, object result = null, CancellationToken cancellationToken = default)
        {
            recursions = Convert.ToInt32(result);
            await outerDc.PromptAsync(nameof(TextPrompt), new PromptOptions
            {
                Prompt = MessageFactory.Text($"Resume root dialog with recursion value {recursions}")
            });
            return await outerDc.BeginDialogAsync(nameof(WaterfallDialog));
        }
    }
