        public DialogBot(ConversationState conversationState, UserState userState, T dialog, ILogger<DialogBot<T>> logger)
        {
            _conversationState = conversationState;
            _userState = userState;
            _dialog = dialog;
            _logger = logger;
            //_conversationState = new ConversationState(_myStorage);
            metaAccess = _conversationState.CreateProperty<FilterHolder>("metaNV");
            userProfileAccess = _userState.CreateProperty<UserProfile>("userprofile");
        }
OnEventActivityAsync:
        protected override async Task OnEventActivityAsync(ITurnContext<IEventActivity> turnContext, CancellationToken cancellationToken)
        {
            string[] paths = { ".", "Helpers", "a.json" };
            string fullPath = Path.Combine(paths);
            System.IO.File.WriteAllText(fullPath, "-->The Filter from the event is: " + turnContext.Activity.Name + "\n");
            System.IO.File.AppendAllText(fullPath, "-->The Conversation in Event is: " + turnContext.Activity.Conversation.Id + "\n");
           var userProfile = await userProfileAccess.GetAsync(turnContext, () => new UserProfile(), cancellationToken);
 if (userProfile.hasFirstConversationId == false)
            {
                userProfile.hasFirstConversationId = true;
                userProfile.conversationId = turnContext.Activity.Conversation.Id;
                System.IO.File.AppendAllText(fullPath, "-->The UserState userProfileId in Event is the first, it is: " + userProfile.conversationId + "\n");
            }
            else
            {
                System.IO.File.AppendAllText(fullPath, "-->The UserState userProfileId in Event is not the first, it is: " + userProfile.conversationId + "\n");
                turnContext.Activity.Conversation.Id = userProfile.conversationId;
                System.IO.File.AppendAllText(fullPath, "-->The new Conversation in Event is: " + turnContext.Activity.Conversation.Id + "\n");
            }
            await userProfileAccess.SetAsync(turnContext, userProfile, cancellationToken);
            await _userState.SaveChangesAsync(turnContext, false, cancellationToken);
            //--Filters
            var settheFilter = await metaAccess.GetAsync(turnContext, () => new FilterHolder(), cancellationToken);
            settheFilter.filter = turnContext.Activity.Name;
            await metaAccess.SetAsync(turnContext, settheFilter, cancellationToken);
            await _conversationState.SaveChangesAsync(turnContext, false, cancellationToken);
NOTE: While this solves the question in this post, there is still an error that all users talking to the bot will be put into the same conversation. So if User A is on the Queen Page, and then User B goes to the King Page, Users A's filters will be updated to king-kingvalue, instead of staying queen-queen value. I will post this problem elsewhere, but just thought I should mention it!
