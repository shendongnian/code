    [Test]
    public void WhenTheViewModelIsLoaded_TheSystem_ShouldRecordOneNewResource()
    {
       // arrange
       var serverAdapterMock = new Mock<IServerAdapter>();
       var subject = new SubjectUnderTest( serverAdapterMock.Object );
       // act
       subject.Initialize();
       
       // assert
       serverAdapterMock.Verify( c => c.CallServer( IsAddResource() ), Times.Exactly(1));
    }
    static Expression<Action<IServerExposedToClient>> IsAddResource()
    {
        return Match.Create<Expression<Action<IServerExposedToClient>>>(
                  exp => GetMethodName(exp) == "AddResource");
    }
