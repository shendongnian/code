	//Using untyped versions
	IMessagingExchange exchange = new RabbitExchange();
	IMessagingQueue queue = new RabbitQueue();
    //This works fine
	exchange.Bind(queue);
	//Attempt to use the wrong queue
	IMessagingQueue memoryQueue = new InMemoryQueue();
	//This results in an error
	exchange.Bind(memoryQueue);
