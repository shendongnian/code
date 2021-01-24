    private static IEnumerable<IEnumerable<Message>> GetPartitionedMessages(IEnumerable<Message> messages, int nPartitions)
    {
        var orderedMessages = messages.OrderBy(x => x.UserId).ThenBy(x => x.MessageId).ToList();
        int? lastUserId = null;
        int maxPartitionSize = (int)Math.Ceiling(orderedMessages.Count / (double)nPartitions);
        var partitions = new List<List<Message>>();
        List<Message> currentPartition = null;
    
        foreach (var message in orderedMessages)
        {
            if (lastUserId == message.UserId)
            {
                currentPartition.Add(message);
            }
            else
            {
                lastUserId = message.UserId;
                if (currentPartition == null || currentPartition.Count >= maxPartitionSize)
                {
                    currentPartition = new List<Message>();
                    partitions.Add(currentPartition);
                }
    
                currentPartition.Add(message);
            }
        }
    
        return partitions;
    }
