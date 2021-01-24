     // TODO: build consumer that reads string messages 
    consumer.Subscribe(topics);
    ... 
    while (true) {
        var consumeResult = consumer.Consume(cancellationToken);
        string value = consumeResult.Value;
        // TODO: parse string value to JSON object using your favorite JSON library 
        // Add your condition 
        if (jsonObj["file-name"].Equals("XXXX.txt"))
        {
            Console.WriteLine($"Received message at {consumeResult.TopicPartitionOffset}: {value}");
        }
