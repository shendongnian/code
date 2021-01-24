        public IActionResult CreateConversation(string username, string convname)
        {
            ChatModel model = new ChatModel(username, convname);
            model.Chatters.Add(username);
            ChatController chatController = new ChatController();
            return chatController.Chat(model);
        }
