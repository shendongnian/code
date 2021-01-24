    [TestMethod]
    public void Should_FindFloorByName() {
        using (var mock = AutoMock.GetLoose()) {
            //Arrange
            string expected = "First Floor";
            var floor = new FloorInfo { Name = expected };
            FloorManager subject = mock.Create<FloorManager>();
            mock.Mock<IFloorCollection>()
                .Setup(_ => _.Find(It.Is<Func<FloorInfo, bool>>(f => f(floor))))
                .Returns(floor);
            //Act
            FloorInfo actual = subject.FindFloorByName(expected);
            //Assert - FluentAssertions
            actual.Should().NotBeNull();
            actual.Name.Should().Be(expected);
        }
    }
