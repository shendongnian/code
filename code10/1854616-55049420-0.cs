    [Test]
    public void MogMethodThatReturnsADifferentValueWhenCalledASecondTimeUsingSequences()
    {
        Mock<ISomeService> _mockSomeService = new Mock<ISomeService>();
        _mockSomeService.SetupSequence(x => x.GetNextStuff())
                .Returns(new SomeStuff {Id = 1, Name = "Real"})
                .Returns(null);
     
        Assert.IsNotNull(_mockSomeService.Object.GetNextStuff());
        Assert.IsNull(_mockSomeService.Object.GetNextStuff());
    }
