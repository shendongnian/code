    public static class TimeoutConversations
        {
            const int TimeoutLength = 10;
            private static Timer _timer;
            private static TimeSpan _timeoutLength;
    
            static TimeoutConversations()
            {
                _timeoutLength = TimeSpan.FromSeconds(TimeoutLength);
                _timer = new Timer(CheckConversations, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            }
    
            static ConcurrentDictionary<string, UserInfo> Conversations = new ConcurrentDictionary<string, UserInfo>();
    
            static async void CheckConversations(object state)
            {
                foreach (var userInfo in Conversations.Values)
                {
                    if (DateTime.UtcNow - userInfo.LastMessageReceived >= _timeoutLength)
                    {
                        UserInfo removeUserInfo = null;
                        Conversations.TryRemove(userInfo.ConversationReference.User.Id, out removeUserInfo);
    
                        var activity = userInfo.ConversationReference.GetPostToBotMessage();
                        //clear the dialog stack and conversation state for this user
                        using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, activity))
                        {
                            var botData = scope.Resolve<IBotData>();
                            await botData.LoadAsync(CancellationToken.None);
    
                            var stack = scope.Resolve<IDialogStack>();
                            stack.Reset();
    
                            //botData.UserData.Clear();
                            botData.ConversationData.Clear();
                            botData.PrivateConversationData.Clear();
                            await botData.FlushAsync(CancellationToken.None);
                        }
    
                        MicrosoftAppCredentials.TrustServiceUrl(activity.ServiceUrl);
                        var connectorClient = new ConnectorClient(new Uri(activity.ServiceUrl), ConfigurationManager.AppSettings["MicrosoftAppId"], ConfigurationManager.AppSettings["MicrosoftAppPassword"]);
                        var reply = activity.CreateReply("I haven't heard from you in awhile.  Let me know when you want to talk.");
                        connectorClient.Conversations.SendToConversation(reply);
    
                        //await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
                    }
                }
            }
    
            public static void MessageReceived(Activity activity)
            {
                UserInfo userInfo = null;
                if (Conversations.TryGetValue(activity.From.Id, out userInfo))
                {
                    userInfo.LastMessageReceived = DateTime.UtcNow;
                }
                else
                {
                    Conversations.TryAdd(activity.From.Id, new UserInfo()
                    {
                        ConversationReference = activity.ToConversationReference(),
                        LastMessageReceived = DateTime.UtcNow
                    });
                }
            }
        }
        public class UserInfo
        {
            public ConversationReference ConversationReference { get; set; }
            public DateTime LastMessageReceived { get; set; }
        }
