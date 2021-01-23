    Thread producer = new Thread(TransactionProducer);
    Thread consumer1 = new Thread(TransactionConsumer);
    Thread consumer2 = new Thread(TransactionConsumer);
    
    producer.Start();
    consumer1.Start();
    consumer2.Start();
    
    // At this point, you are processing transactions.
    // The main thread waits for all threads to exit.
    producer.Join();
    consumer1.Join();
    consumer2.Join();
