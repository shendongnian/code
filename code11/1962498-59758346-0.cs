csharp
	// Arrange
	var provider = new ProduceResponseTypeModelProvider();
	var methodInfoMock = new Mock<MethodInfo>();
	var yourKnownType = typeof(int);
	methodInfoMock.Setup(m => m.ReturnType).Returns(yourKnownType).Verifiable(); // you mock the actual property
	methodInfoMock.Setup(m => m.Filters.Add(It.IsAny<ProducesResponseTypeAttribute>())).Verifiable(); // with .Verifiable() Moq will make a note of calls to action.Filters.Add()
	var actionModel = new ActionModel(methodInfoMock.Object, new List<object>() { });
	// Act
	// Assert
	methodInfoMock.Verify(m => m.Filters.Add(It.Is<ProducesResponseTypeAttribute>(x => x.HasReturnType)), Times.Once); // checks if action.Filters.Add has been called with an instance of ProducesResponseTypeAttribute that had a returnType (i made the check up but hopefully you get the gist)
	methodInfoMock.Verify(m => m.Filters.Add(It.Is<ProducesEmptyResponseTypeAttribute>(x => x.HasReturnType)), Times.Never); // suppose ProducesEmptyResponseTypeAttribute inherits from ProducesResponseTypeAttribute and can also be passed to your mock. check it here 
	methodInfoMock.Verify(m => m.ReturnType, Times.Exactly(2)); // suppose you're expecting it to have been called twice
Then you can verify that a particular mock has been invoked and check types/values on the invocation. 
2. If the internal state is overpowering and cannot be mocked out (because, say, your behaviour depends on it), you can opt to offload some internal calculations to actual object instance that you instantiate yourself. Out of the box Moq doesn't allow you to do it, but it's possible to subclass `Mock` and make it wrap instances with call to actual implementation for all methods that you haven't `Setup`. One example of that can be found in my [other SO answer][1]. I suspect this might apply to your case if you want to mock out some bits of `ActionModel` while generally sticking to its implementation.
  [1]: https://stackoverflow.com/questions/59660284/creating-mock-with-moq-around-existing-instance/59664654#59664654
