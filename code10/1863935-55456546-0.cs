using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Bot.Dialogs.Authentication;
using Bot.Dialogs.Main;
using Bot.Dialogs.Onboarding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Bot.Dialogs.Shared
{
    public class AuthenticatedDialog : EnterpriseDialog
    {
        private BotStateAccessors _accessors;
        private BotServices _botServices;
        public AuthenticatedDialog(BotServices botServices, string dialogId, BotStateAccessors accessors) : base(botServices, dialogId)
        {
            _accessors = accessors;
            _botServices = botServices;
            AddDialog(new AuthenticationDialog("", accessors));
        }
        protected async Task<DialogTurnResult> AskForOnboardingAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken, object stepResult = null)
        {
            return await stepContext.BeginDialogAsync(nameof(OnboardingDialog), stepResult, cancellationToken);
        }
        protected void AddOnboardingDialog()
        {
            AddDialog(new OnboardingDialog(_botServices,_accessors));
        }
    }
}
**DialogA.cs**
public class DialogA : AuthenticatedDialog
{
        public DialogA(BotServices botServices, BotStateAccessors accessors) : base(botServices, nameof(DialogA), accessors)
        {
            var preferencesDispatchSteps = new WaterfallStep[]
            {
                WaterfallStepA,
                WaterfallStepB
            };
            AddDialog(new FooDialog);
            AddOnboardingDialog();
        }
}
 
