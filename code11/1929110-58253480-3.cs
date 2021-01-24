        public ActionResult CreateConversation(string username, string convname)
        {
            Guid chatId = yourServiceFactory.CreateNewChat(username, convname);
            // You passed the service the username anyway so it can do the Chatters.Add() internally
            return RedirectToAction("Chat", "Chat", new { id = chatId });
        }
