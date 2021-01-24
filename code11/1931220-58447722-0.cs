     public class CancelDialog : ComponentDialog
    {
        private static string attachmentPromptId = $"{nameof(CancelDialog)}_attachmentPrompt";
        public CancelDialog()
            : base(nameof(CancelDialog))
        {
           
            // This array defines how the Waterfall will execute.
            var waterfallSteps = new WaterfallStep[]
            {
                TitleStepAsync,
                DescStepAsync,
              //  AskForAttachmentStepAsync,
                UploadAttachmentAsync,
                UploadCodeAsync,
                SummaryStepAsync,
            };
            // Add named dialogs to the DialogSet. These names are saved in the dialog state.
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallSteps));
            AddDialog(new TextPrompt(nameof(TextPrompt)));
            AddDialog(new NumberPrompt<int>(nameof(NumberPrompt<int>), AgePromptValidatorAsync));
            AddDialog(new ChoicePrompt(nameof(ChoicePrompt)));
            AddDialog(new ConfirmPrompt(nameof(ConfirmPrompt)));
            AddDialog(new AttachmentPrompt(attachmentPromptId));
