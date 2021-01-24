            [Test]
            public void Test1()
            {
                // Mock the dependency
                Mock<ITestContext> mockContext = new Mock<ITestContext>();
                mockContext.Setup(m => m.Add(It.IsAny<Item>()))
                    .Returns(true);
                mockContext.Setup(m => m.SaveChanges())
                    .Returns(true);
    
                // Inject the dependency
                TestClass testClass = new TestClass(mockContext.Object);
    
                int result = testClass.DoSomething("Whatever");
                
                // Verify the methods on the mock were called once
                mockContext.Verify(m => m.Add(It.IsAny<Item>()), Times.Once);
                mockContext.Verify(m => m.SaveChanges(), Times.Once);
                 
                // Assert that the result of the operation is the expected result defined elsewhere
                Assert.That(result, Is.EqualTo(ExpectedResult));
            }
