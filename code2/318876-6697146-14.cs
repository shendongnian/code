                    IModel channel = ...;
            	QueueingBasicConsumer consumer = new QueueingBasicConsumer(channel);
            	channel.BasicConsume(queueName, false, null, consumer);  //<-----
            	channel.BasicConsume(queueName2, false, null, consumer); //<-----
            	// etc. channel.BasicConsume(queueNameN, false, null, consumer);  //<-----
            	
            	// At this point, messages will be being asynchronously delivered,
            	// and will be queueing up in consumer.Queue.
            	
            	while (true) {
            	    try {
            	        BasicDeliverEventArgs e = (BasicDeliverEventArgs) consumer.Queue.Dequeue();
            	        // ... handle the delivery ...
            	        channel.BasicAck(e.DeliveryTag, false);
            	    } catch (EndOfStreamException ex) {
            	        // The consumer was cancelled, the model closed, or the
            	        // connection went away.
            	        break;
            	    }
            	}
