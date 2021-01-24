    //Arrange
    var fixture = new Fixture().Customize(new AutoMoqCustomization());
    var runnerParam = fixture.Freeze<Mock<IRunnerParam>>()
        .Setup(_ => _.Multiplicator())
        .Returns(2);
    var subjectMock = fixture.Freeze<Mock<Runner>>();
    subjectMock.CallBase = true;
    subjectMock.Setup(_ => _.Run()).Returns(5);
    int expected = 500;
    Runner sut = subjectMock.Object;
    //Act
    var actual = sut.RunImplementation(5); // should be 500
    //Assert
    actual.Should().Be(expected);
