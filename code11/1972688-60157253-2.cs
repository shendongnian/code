    [Fact]
    public async Task MyImplementedInterface_GetActive_ReturnsDataOrEmptyList() {
        using (var mock = AutoMock.GetLoose()) {
            //Arrange
            IList<MyObj> expected = _SomeStaticDataRepresentation;
            mock.Mock<IDataInterface>()
                .Setup(x => x.GetData<MyObj>(It.IsAny<string>()))
                .ReturnAsync(expected);
            var svc = mock.Create<MyService>();
            //Act
            var actual = await svc.GetActiveObjs();
            //Assert
            Assert.True(actual != null);
            Assert.True(actual == expected);
            // ...
        }
    }
