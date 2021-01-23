    public IQueryable<Message> GetMessages(int user_id)
    {    
        // Get MessageReceiver tables that share receiver id
        var messageReceivers = GetMessageReceivers().Where(messageReceiver => messageReceiver.receiver_id == user_id);
        
        // get all messages that have been recieved by a user
        var messages = from m in DataContext.Messages
                       join r in messageReceivers
                       on m.id equals r.message_id
                       select m;                  
        
        //return the messages
        return messages;
    }
