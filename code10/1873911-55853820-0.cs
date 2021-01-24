    var channelsList = new List<IChannel>
    {
        Mock.Of<IChannel>(m => m.DoWork() == 1),
        Mock.Of<IChannel>(m => m.DoWork() == 2)
    };
    
    Assert.Equal(1, channelsList.First().DoWork());
    Assert.Equal(2, channelsList.Last().DoWork());
