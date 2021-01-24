    public void Test_SystemUnderTest() {
        using (var mock = AutoMock.GetLoose()) {
            // Setup
            var dependency = mock.Mock<Dependency>();
            dependency.CallBase = true;
            dependency.Setup(x => x.GetValueTwo()).Returns("expected value");
            // Configure
            mock.Provide<IDependency>(dependency.Object);
            // Arrange - configure the mock
            var sut = mock.Create<SystemUnderTest>();
            // Act
            var actual_GetValueOne = sut.GetValueOne();
            var actual_GetValueTwo = sut.GetValueTwo();
            // Assert - assert on the mock
            Assert.AreEqual("get-value-one", actual_GetValueOne);
            Assert.AreEqual("expected value", actual_GetValueTwo);
        }
    }
