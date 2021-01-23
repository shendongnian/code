    [Setup]   
    public void Setup()
    {
        this.mockAllianceController = new Mock<AllianceController>();
        this.testObj = new DiplomacyLogic(this.mockAllianceController.Object);
        this.mockAllianceController.Setup(ac => ac.getAllies(this.currentRealm)).Returns(new         List<string>());
    }
    [TearDown]
    public void TearDown()
    {
        this.mockAllianceController = null;
        this.testObj = null;
    }
