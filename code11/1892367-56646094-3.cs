    // Sender is reused across requests
    public class BatchSender
    {
        private readonly QueueClient queueClient;
        private long batchSizeLimit = 262000;
        private long headerSizeEstimate = 54; // start with the smallest header possible
    
        public BatchSender(QueueClient queueClient)
        {
            this.queueClient = queueClient;
        }
    
        public async Task SendBigBatchAsync<T>(IEnumerable<T> messages)
        {
            var packets = (from m in messages
                         let bm = new BrokeredMessage(m)
                         select new { Source = m, Brokered = bm, BodySize = bm.Size }).ToList();
            var chunks = packets.ChunkBy(p => this.headerSizeEstimate + p.Brokered.Size, this.batchSizeLimit);
            foreach (var chunk in chunks)
            {
                try
                {
                    await this.queueClient.SendBatchAsync(chunk.Select(p => p.Brokered));
                }
                catch (MessageSizeExceededException)
                {
                    var maxHeader = packets.Max(p => p.Brokered.Size - p.BodySize);
                    if (maxHeader > this.headerSizeEstimate)
                    {
                        // If failed messages had bigger headers, remember this header size 
                        // as max observed and use it in future calculations
                        this.headerSizeEstimate = maxHeader;
                    }
                    else
                    {
                        // Reduce max batch size to 95% of current value
                        this.batchSizeLimit = (long)(this.batchSizeLimit * .95);
                    }
    
                    // Re-send the failed chunk
                    await this.SendBigBatchAsync(packets.Select(p => p.Source));
                }
    
            }
        }
    }
