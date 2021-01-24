    var _mockedKafkaTopicConsumerManager = Mock.Get(serviceProvider.GetService<IKafkaTopicConsumerManage>());
    _mockedKafkaTopicConsumerManager
        .Verify(c => c.StartConsumption(
            It.IsAny<CancellationToken>(), 
            _mockedMessageProcessor.Object,
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<List<string>>(),
            It.IsAny<string>(),
            It.IsAny<int>()
    ),Times.Once);
