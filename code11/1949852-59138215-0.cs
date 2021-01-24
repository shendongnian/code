    [TestClass]
    public class ClassGoingToBeUnitTestedTest
    {
        // mock of I interface
        private I IMock;
    
        // mock of ISomeService
        private ISomeService someServiceMockInstance;
    
        // ClassGoingToBeUnitTested object
        ClassGoingToBeUnitTested classGoingToBeUnitTested;
    
        [TestInitialize]
        public void init()
        {
            this.IMock = Substitute.For<I>();
            this.ISomeService = Substitute.For<ISomeService>();
            this.classGoingToBeUnitTested = new ClassGoingToBeUnitTested(this.IMock);
        }
    
    
        [TestMethod]
        public void methodToBeUnitTested_Success()
        {
            // Arrange
            var cancellationTokenSource = new CancellationTokenSource();
            this.IMock.invokedMethod(
                Arg.Any<string>,
                Arg.Do<Func<IService, Task>(x => x.Invoke(this.someServiceMockInstance)));
    
            // Act
            this.classGoingToBeUnitTested.methodToBeUnitTested(cancellationTokenSource.Token);
    
            // Assert
            this.IMock.Received(1).invokedMethod(
                 "Name1",
                 Arg.Any<Func<IService, Task>()); // changed this
            this.IMock.Received(1).invokedMethod(
                 "Name2",
                 Arg.Any<Func<IService, Task>()); // added this as well
    
            // adding to check the Received call on the service instance
            this.someServiceMockInstance.Received(2).CleanupMethod(cancellationTokenSource.Token);
        }
    }
