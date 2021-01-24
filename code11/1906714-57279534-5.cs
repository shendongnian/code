    [Fact]
    public async Task Should_Return_Ok_ReturnRsult() {
        //Arrange
        var id = "456";
        var dealerId = "123";
        SettingsInfo expected = new SettingsInfo() {
            DealerId = dealerId,
            Name="Dealer1"
        };
        
        var pairingMock = new Mock<ICarPairingTable>();
        pairingMock.Setup(p => p.GetDealerId(id)).ReturnsAsync(dealerId);
        var dealerSettingsMock = new Mock<ICarDealerSettingsTable>();
        dealerSettingsMock.Setup(p => p.GetSettingsInfo(dealerId)).ReturnsAsync(() => expected);
        CarController controller = new CarController(new AppSettings(),  pairingMock.Object, dealerSettingsMock.Object);
        //Act
        var actionResult = await controller.Get(id);
        var actual = actionResult as OkObjectResult;
        //Assert (using FluentAssertions)
        actual.Should().NotBeNull();
        
        actual.Value.Should().BeOfType<ReturnResult>();
        var actualResult = actual.Value as ReturnResult;
        actualResult.data.Should().BeEquivalentTo(expected);        
    }
