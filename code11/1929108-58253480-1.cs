        public ActionResult Chat(Guid id)
        {
            ChatModel model = yourServiceFactory.GetChatById(id);
            return View(model);
        }
