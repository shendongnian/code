    public IQueryable<Message> GetMessages(int user_id)
    {
        // Get MessageReceiver tables that share receiver id
        IQueryable<MessageReceiver> messageReceivers = GetMessageReceivers().Where(messageReceiver => messageReceiver.receiver_id == user_id);
        //get the ids of the messages that we want to get
        var messageIds = messageReceivers.Select(r => r.message_id).ToList();
        //filter the query by the ids that we're looking for
        return DataContext.Messages.Where(m => messageIds.Contains(m.id));
    }
