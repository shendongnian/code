    [TestMethod]
    public void TestMoqInvocations()
    {
        var notifierMock = new Mock<INotifier>();
        var svc = new NotificationService(new List<INotifier>{ notifierMock.Object });    
        svc.SendNotifications();
        var invocations = new List<NotifyParams>();
        notifierMock
            .Setup(f => f.Notify(It.IsAny<User>(), It.IsAny<User>()))
            .Callback<string, string>((user, friend) => invocations.Add(new NotifyParams{user = user, friend = friend}));
        Assert.AreEqual(1, invocations[0].user.UserId);
        Assert.IsNull(invocations[0].friend);
        Assert.AreEqual(1, invocations[1].user.UserId);
        Assert.AreEqual(2, invocations[1].user.UserId);
    }
        public struct NotifyParams { 
           public User user {get;set;}
           public User friend { get; set; }
        }
