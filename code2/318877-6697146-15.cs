                ch.QueueDeclare(queueName);
                BasicGetResult result = ch.BasicGet(queueName, false);
                if (result == null) {
                    Console.WriteLine("No message available.");
                } else {
                    ch.BasicAck(result.DeliveryTag, false);
                    Console.WriteLine("Message:"); 
                    // deserialize body and display extra info here.
                }
