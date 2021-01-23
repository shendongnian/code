    MessagingFactory msgFactory = MessagingFactory.Create(_uri, _tokenProvider);
            MessageReceiver msgReceiver = msgFactory.CreateMessageReceiver("[topic]/subscriptions/[subscription]/$DeadLetterQueue", ReceiveMode.PeekLock);
            while (true)
            {
                BrokeredMessage msg = msgReceiver.Receive();
                if (msg != null)
                {
                    Console.WriteLine("Deadlettered message.");
                    Console.WriteLine("MessageId:                  {0}", msg.MessageId);
                    Console.WriteLine("DeliveryCount:              {0}", msg.DeliveryCount);
                    Console.WriteLine("EnqueuedTimeUtc:            {0}", msg.EnqueuedTimeUtc);
                    Console.WriteLine("Size:                       {0} bytes", msg.Size);
                    Console.WriteLine("DeadLetterReason:           {0}",
                        msg.Properties["DeadLetterReason"]);
                    Console.WriteLine("DeadLetterErrorDescription: {0}",
                        msg.Properties["DeadLetterErrorDescription"]);
                    Console.WriteLine();
                    msg.Complete();
                }
            }
