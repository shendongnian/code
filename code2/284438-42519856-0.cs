                Queue.Formatter = new XmlMessageFormatter(new Type[] { typeof(String) });
            // The Receive() call here is a blocking call.  We'll wait if there is no message in the queue, and processing
            // is halted until there IS a message in the queue.
            //
            try
            {
                Queue.Send("hello world", System.Messaging.MessageQueueTransactionType.Single);
                var msg = Queue.Receive(MessageQueueTransactionType.Single);
                
            }
            catch (Exception ex)
            {
                // todo error handling
            }
