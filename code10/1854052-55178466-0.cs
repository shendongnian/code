    public class ConversationStarter
    {
        public static string fromId;
        public static string fromName;
        public static string toId;
        public static string toName;
        public static string serviceUrl;
        public static string channelId;
        public static string conversationId;
        public static async Task Resume(string conversationId, string channelId)
        {
            conversationId = await Talk(conversationId, channelId, $"Hi there!");
            conversationId = await Talk(conversationId, channelId, $"This is a notification!");
        }
        private static async Task<string> Talk(string conversationId, string channelId, string msg)
        {
            var userAccount = new ChannelAccount(toId, toName);
            var botAccount = new ChannelAccount(fromId, fromName);
            var connector = new ConnectorClient(new Uri(serviceUrl));
            IMessageActivity message = Activity.CreateMessageActivity();
            if (!string.IsNullOrEmpty(conversationId) && !string.IsNullOrEmpty(channelId))
            {
                message.ChannelId = channelId;
            }
            else
            {
                conversationId = (await connector.Conversations.CreateDirectConversationAsync(botAccount, userAccount)).Id;
            }
            message.From = botAccount;
            message.Recipient = userAccount;
            message.Conversation = new ConversationAccount(id: conversationId);
            message.Text = msg;
            message.Locale = "en-Us";
            await connector.Conversations.SendToConversationAsync((Activity)message);
            return conversationId;
        }
    }
