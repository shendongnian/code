        [Fact]
        public async Task Test_SystemUnderTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var mockedDependency = mock.Mock<IDependency>();
                // Setup
                mockedDependency.Setup(x => x.GetValueOne()).Returns("get-value-one");
                mockedDependency.Setup(x => x.GetValueTwo()).Returns("expected value");
                mock.Provide<IDependency>(mockedDependency.Object);
                // Arrange - configure the mock
                var sut = mock.Create<SystemUnderTest>();
                // Act
                var actual_GetValueOne = sut.GetValueOne();
                var actual_GetValueTwo = sut.GetValueTwo();
                // Assert - assert on the mock
                Assert.Equal("get-value-one", actual_GetValueOne);
                Assert.Equal("expected value", actual_GetValueTwo);
            }
        }
