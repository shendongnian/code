    public class TestControllerTest {
            
        [Fact]
        public async Task Post_TakesTestString_ReturnsString() {
            //Arrange
            var MockTestService = new Mock<ITestService>();
            var MockController = new Mock<TestController>(MockTestService.Object) {
                CallBase = true //<--
            };
            MockController.Protected().Setup<string>("GetString", ItExpr.IsAny<string>()).Returns("testMockValue").Verifiable();
            TestController controller = MockController.Object;
            //Act
            var result = await controller.Post(new TestModel() { });
            
            //Assert    
            MockController.Protected().Verify("GetString", Times.Once(), ItExpr.IsAny<string>());
        }
    }
