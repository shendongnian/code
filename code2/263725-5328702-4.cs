    public IQueryable<Message> GetMessages(int user_id)
    {
        // Get MessageReceiver tables that share receiver id
        IQueryable<MessageReceiver> messageReceivers = GetMessageReceivers().Where(messageReceiver => messageReceiver.receiver_id == user_id);
        // only return messages that have a matching message reciever
        return DataContext.Messages.Where(m => messageReceivers.Any(r => r.message_id == m.id));
    }
