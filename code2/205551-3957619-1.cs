        public void AsyncWatchQueue(object encapsulatedQueueName)
        {
            Message newMessage;
            MessageQueue queue;
            
            string queueName = encapsulatedQueueName as string;
            if (queueName == null)
                return;
            try
            {
                if (!MessageQueue.Exists(queueName))
                    MessageQueue.Create(queueName);
                else
                {
                    queue = new MessageQueue(queueName);
                    if (queue.CanRead)
                        newMessage = queue.Receive();
                }
                HandleNewMessage(newMessage); // Do something with the message
            }
            // This exception is raised when the Abort method 
            // (in the thread's instance) is called
            catch (ThreadAbortException e) 
            {
                //Do thread shutdown
            }
            finally
            {
                queue.Dispose();
            }
        }
