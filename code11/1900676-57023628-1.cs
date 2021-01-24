var feedback = ((Activity)context.Activity).CreateReply("Did you find what you need?");
feedback.SuggestedActions = new SuggestedActions()
{
    Actions = new List<CardAction>()
    {
        new CardAction(){ Title = "Yes", Type=ActionTypes.PostBack, Value=$"yes-positive-feedback" },
        new CardAction(){ Title = "No", Type=ActionTypes.PostBack, Value=$"no-negative-feedback" }
    }
};
await context.PostAsync(feedback);
---
**EDIT**
Thank you for providing the full code for your `QnADialog` class, unfortunately I cannot run it locally because the implementations for methods such as `GetQnaIdColl`, `GetNextRotationKey`, `TextFormatter.FormattedQuestionColl` among other methods and classes that you call but haven't provided. Your code for prompting a user for a response looks right but it sounds like you're not even getting the feedback prompt to show, or you're getting the feedback prompt to show but you get stuck on there - can you confirm which it is? Have you tried stepping through the code to see which path it takes?
Another suggestion would be to separate out your QnA step and Feedback steps into separate Dialogs, I have proved and example feedback dialog below.
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using System.Threading;
using System.Threading.Tasks;
namespace ChatBot.VirtualAssistant.Dialogs
{
    public class RateAnswerDialog : ComponentDialog
    {
        public RateAnswerDialog()
            : base(nameof(RateAnswerDialog))
        {
            InitialDialogId = nameof(RateAnswerDialog);
            var askToRate = new WaterfallStep[]
            {
                AskRating,
                FinishDialog
            };
			AddDialog(new TextPrompt(nameof(TextPrompt)));
			AddDialog(new WaterfallDialog(InitialDialogId, askToRate));
        }
        private async Task<DialogTurnResult> AskRating(WaterfallStepContext sc, CancellationToken cancellationToken)
        {
			PromptOptions promptOptions = new PromptOptions
			{
				Prompt = MessageFactory.Text("Was this helpful?")
			};
			return await sc.PromptAsync(nameof(TextPrompt), promptOptions);
		}
        private async Task<DialogTurnResult> FinishDialog(WaterfallStepContext sc, CancellationToken cancellationToken)
        {
            return await sc.EndDialogAsync(sc);
        }
        protected override async Task<DialogTurnResult> EndComponentAsync(DialogContext outerDc, object context, CancellationToken cancellationToken)
        {
			var waterfallContext = (WaterfallStepContext)context;
			var userResponse = ((string)waterfallContext.Result).ToLowerInvariant();
            if (userResponse == "yes")
            {
				await waterfallContext.Context.SendActivityAsync("Thank you for your feedback");
            }
            else if (userResponse == "no")
            {
				await waterfallContext.Context.SendActivityAsync("Sorry I couldn't help you");
            }
			else
			{
				await waterfallContext.Context.SendActivityAsync("The valid answers are 'yes' or 'no'");
				// TODO reprompt if required
			}
			return await outerDc.EndDialogAsync();
        }
    }
}
