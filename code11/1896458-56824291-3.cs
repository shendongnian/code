	[TestMethod]
	public void AddQuestion()
	{
		// Arrange
		var contextMock = new Mock<IAbcdContext>();
		contextMock.Setup(r => r.AddQuestion(It.IsAny<Question>())).Returns(1);
		var sut = new SqLiteAbcdRepository(contextMock.Object);
		
		// Act
		var id = sut.AddQuestion(new Question());
		
		// Assert
		Assert.AreEqual(1, id);
	}
