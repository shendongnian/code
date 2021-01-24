for (int i = 0; i < 10; i++)
{
    var consumerBuilder = new ConsumerBuilder<Ignore, string>(GetConfig())
    .SetErrorHandler((_, e) => _logger.LogError("Kafka consumer error on Revenue response. {@KafkaConsumerError}", e));
    using (var consumer = consumerBuilder.Build())
    {
        // your processing here
    }
}
