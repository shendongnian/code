    [Serializable]
    [QnAMaker("####", "###",
        "Sorry I could not find an answer to your  question", 0.5, 1, "website" )]
    public class QnAHeroesDialog : QnAMakerDialog
    {
        protected override async Task RespondFromQnAMakerResultAsync(IDialogContext context, IMessageActivity message, QnAMakerResults results)
        {
            if (results.Answers.Count > 0)
            {
                var foundReply = results.Answers.First().Answer;
                var response = $"{foundReply.Replace("\n\n", "\n")}";
                await context.PostAsync(response);
            }
        }
    }
