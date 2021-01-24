        public async Task Send(string userId)
        {
            var message = $"Send message to you with user id {userId}";
            await Clients.Client(userId).SendAsync("ReceiveMessage", message);
        }
        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
