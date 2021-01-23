       public class StdQueue<T> where T : BaseMessage, new()
        {
            protected CloudQueue queue;
    
            public StdQueue(CloudQueue queue)
            {
                this.queue = queue;
            }
    
            public void AddMessage(T message)
            {
                CloudQueueMessage msg =
                new CloudQueueMessage(message.ToBinary());
                queue.AddMessage(msg);
            }
    
            public void DeleteMessage(CloudQueueMessage msg)
            {
                queue.DeleteMessage(msg);
            }
    
            public CloudQueueMessage GetMessage()
            {
                return queue.GetMessage(TimeSpan.FromSeconds(120));
            }
        }
