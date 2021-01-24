    public class Bot {
        public DiscordSocketClient client;
    
        public Bot() {
            //Initialize your client here...
            client = new DiscordSocketClient(/* ... */);
    
            client.ReactionAdded += ReactionAdded_Event;
        }
    
        public void ReactionAdded_Event(Cacheable<IUserMessage, UInt64> message, ISocketMessageChannel channel, SocketReaction reaction)
        {
            //Check if the message is in the right channel, if it's the emoji you want, etc...
        }
    }
