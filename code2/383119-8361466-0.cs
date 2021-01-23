    public void GetEmployeeTest()
        {
            Domain target = new Domain();
            var mockHttpContext = new Mock<HttpContextBase>();
            var mockSession = new Mock<HttpSessionStateBase>();
            mockHttpContext.SetupGet(c => c.Session).Returns(mockSession.Object);
            mockHttpContext.SetupSet(c => c.Session["Employee"] = It.IsAny<object>());
            Assert.IsTrue(target.IsValidEmployee("sam@gmail.com", "test"));
        }
