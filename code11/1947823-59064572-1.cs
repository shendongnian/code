    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder;
    using Microsoft.Bot.Schema;
    using Microsoft.Bot.Builder.AI.QnA;
    
    namespace Microsoft.BotBuilderSamples
    {
        public class StateManagementBot : ActivityHandler
        {
            private BotState _conversationState;
            private BotState _userState;
            private string KBID = "<KBID>";
            private string ENDPOINT_KEY = "<KEY>";
            private string HOST = "<QnA maker host>";
    
    
            public StateManagementBot(ConversationState conversationState, UserState userState)
            {
                _conversationState = conversationState;
                _userState = userState;
            }
    
            public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
            {
                await base.OnTurnAsync(turnContext, cancellationToken);
    
                // Save any state changes that might have occured during the turn.
                await _conversationState.SaveChangesAsync(turnContext, false, cancellationToken);
                await _userState.SaveChangesAsync(turnContext, false, cancellationToken);
            }
    
            protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
            {
                foreach (var member in membersAdded)
                {
                    if (member.Id != turnContext.Activity.Recipient.Id)
                    {
    
                        var card = new HeroCard();
                        card.Title = "";
                        card.Text = @"Welcome to Welcome Users bot sample! This Introduction card";
                        card.Images = new List<CardImage>() { new CardImage("https://www.google.com/url?sa=i&source=images&cd=&ved=2ahUKEwjQjeeS4obmAhUIfnAKHQGgCB0QjRx6BAgBEAQ&url=https%3A%2F%2Fdougame.tistory.com%2F98&psig=AOvVaw11Y-BZJtsxh1pTp0Qxzedb&ust=1574819546545481") };
                        card.Buttons = new List<CardAction>()
                    {
                        
                        //new CardAction(ActionTypes.OpenUrl, "FAQ", null, "Get an overview", "Get an overview", "https://docs.microsoft.com/en-us/azure/bot-service/?view=azure-bot-service-4.0"),
                        new CardAction(ActionTypes.PostBack, "Info Dynamics365", null, "Ask a question", "Ask a question", "dy365"),
                        new CardAction(ActionTypes.PostBack, "FAQ",null , "Ask a question", "Ask a question", "FAQ"  ),
    
                        new CardAction(ActionTypes.OpenUrl, "Connect", null, "Learn how to deploy", "Learn how to deploy", "https://docs.microsoft.com/en-us/azure/bot-service/bot-builder-howto-deploy-azure?view=azure-bot-service-4.0"),
                    };
    
                        var response = MessageFactory.Attachment(card.ToAttachment());
                        await turnContext.SendActivityAsync(response, cancellationToken);
                    }
                }
    
            }
    
            protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
            {
    
                var qnaMaker = new QnAMaker(new QnAMakerEndpoint
                {
                    KnowledgeBaseId = KBID,
                    EndpointKey = ENDPOINT_KEY,
                    Host = HOST
                },
                        null,
                        new System.Net.Http.HttpClient());
    
                var conversationStateAccessors = _conversationState.CreateProperty<ConversationService>(nameof(ConversationService));
                var conversationService = await conversationStateAccessors.GetAsync(turnContext, () => new ConversationService());
    
                var input = turnContext.Activity.Text;
                if (String.IsNullOrEmpty(conversationService.currentService) && (input.Equals("FAQ") || input.Equals("dy365")))
                {
    
                    conversationService.currentService = input;
                    await turnContext.SendActivityAsync(MessageFactory.Text("using "+ input + " service , pls enter your " + input + " question"), cancellationToken);
    
                } else if (String.IsNullOrEmpty(conversationService.currentService)) {
                    await turnContext.SendActivityAsync(MessageFactory.Text("select a service from hero card first"), cancellationToken);
                }
                else if (conversationService.currentService.Equals("FAQ"))
                {
    
                    var result = qnaMaker.GetAnswersAsync(turnContext).GetAwaiter().GetResult();
    
                    await turnContext.SendActivityAsync(MessageFactory.Text(result[0].Answer), cancellationToken);
                }
                else if (conversationService.currentService.Equals("dy365"))
                {
                    //call your dy 365 service here 
                    await turnContext.SendActivityAsync(MessageFactory.Text("dy365 response"), cancellationToken);
                }
                else {
                    await turnContext.SendActivityAsync(MessageFactory.Text("error"), cancellationToken);
                };
    
            }
        }
    
        public class ConversationService{
            public string currentService { get; set; } 
    }
    
        
    }
