        private void receivemessages()
        {
            Console.WriteLine("Start");
            MessageQueue myQueue = new MessageQueue(@".\private$\myquelocal");
            while (ProcessStatus)
            {
                try
                {
                    // Waits 100 millisec for a message to appear in queue
                    System.Messaging.Message msg = myQueue.Receive(new TimeSpan(0, 0, 0, 0, 100));
                    // Take care of message and insert data into database
                }
                catch (MessageQueueException)
                {
                    // Ignore the timeout exception and continue processing the queue
                    
                }
            }
        }
