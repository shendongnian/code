	[Test]
	public void CallbackVerification()
	{
		Expression<Func<Person, bool>> actualExpression = null;
		var mockUow = new Mock<IUnitOfWork>();
		mockUow
			.Setup(u => u.Single<Person>(It.IsAny<Expression<Func<Person, bool>>>()))
			.Callback( (Expression<Func<Person,bool>> x) => actualExpression = x);
		var uow = mockUow.Object;
		uow.Single<Person>(p => p.FirstName == "Sergi");
		
		Expression<Func<Person, bool>> expectedExpression = p => p.FirstName == "Sergi";
		Assert.AreEqual(expectedExpression.ToString(), actualExpression.ToString());
	}
