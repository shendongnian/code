        private HubConnection connection;
        private IHubProxy proxy;
        public event EventHandler<ChatMessageObject> OnMessageReceived;
        public async Task Connect()
        {
            try
            {
                await connection.Start();
                await proxy.Invoke("Connect", userId); // example method in your backend
                proxy.On("messageReceived", (int userId, string name, string message, DateTime messageDateTime) => OnMessageReceived(this, new ChatMessageObject
                {
                    FromUserId = userId,
                    UserName = name,
                    MessageText = message,
                    MessageDateTime = messageDateTime
                }));
            }
            catch (Exception ex)
            {
                //handle exceptions
            }
        }
