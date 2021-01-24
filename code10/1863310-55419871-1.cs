    [Test]
    public void Get_HasCorrectAuthLevel()
    {
        var controller = new TestController();
        controller.HasExpectedAuthLevel(c => c.Get(), AuthLevel.Client).Should().BeTrue();
        controller.HasExpectedAuthLevel(c => c.GetAsync(), AuthLevel.Server).Should().BeTrue();
    }
