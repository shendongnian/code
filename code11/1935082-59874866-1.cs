    mock.Setup(_ => _.Log(
      It.IsNotNull<LogLevel>(), 
      It.IsNotNull<EventId>(),
      It.IsAny<It.IsValueType>(),
      It.IsNotNull<Exception>(),
      (Func<It.IsValueType, Exception, string>)It.IsAny<object>());
