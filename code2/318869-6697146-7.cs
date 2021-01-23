            using (IModel ch = conn.CreateModel()) {    // btw: no reason to close the channel afterwards IMO
                conn.AutoClose = true;                  // no reason to closs the connection either.  Here for completeness.
                ch.QueueDeclare(queueName);
                BasicGetResult result = ch.BasicGet(queueName, false);
                if (result == null) {
                    Console.WriteLine("No message available.");
                } else {
                    ch.BasicAck(result.DeliveryTag, false);
                    Console.WriteLine("Message:");
                }
                return 0;
            }
    
