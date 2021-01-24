    public ConsumeResult<string, TValue> SubscribeAsync(string topicName)
    {
        consumer.Subscribe(topicName);
        try
        {
           var consumeResult = consumer.Consume();
           ProcessEvents(consumeResult.Value);
           return consumeResult;
        }
        catch (ConsumeException e)
        {
          logger.Error($"Consume error: {e.Error.Reason}");
        }
        return null;
    }
