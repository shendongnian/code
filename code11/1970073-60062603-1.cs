    while (!cancellationToken.IsCancellationRequested)
    {
       ConsumeResult<string, string> consumeResult = _consumer.Consume();
       await channels[consumeResult.Topic].SendAsync(consumeResult);
    }
