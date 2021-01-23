    [Test]
    public void NetworkProviderShouldBeEmailedWhenBackHaulMaximumIsReached()
    {
        var mailerMock = MockRepository.GenerateStub<IMailProvider>();
        var accessPoint = new AccessPoint(mailerMock);
        accessPoint.BackHaulMaximum = 81;
		var actual = accessPoint.BackHaulMaximumReached();
        Assert.AreEqual(true, actual);
		mailerMock.AssertWasCalled(x => x.SendMail());
    }
