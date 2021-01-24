    while (true)
    {
        try
        {
            var consumeResult = consumer.Consume(cts.Token);
            Console.WriteLine($"Key: {consumeResult.Message.Key}\nValue: {consumeResult.Value}");
        }
        catch (ConsumeException e)
        {
            Console.WriteLine($"Consume error: {e.Error.Reason}");
        }
    }
