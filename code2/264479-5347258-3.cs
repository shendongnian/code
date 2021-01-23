    [Test]
    public void AddPlayer_GivesGameEnoughPlayersToStart_SetsNextState()
    {
        // Arrange
        Foo foo = MockRepository.GenerateMock<Foo>(); // Creates mock in Replay mode (what I want for AAA syntax).
        foo.Expect(m => m.Bar = Arg<CorrectBarSubclass>.Is.TypeOf);
        // Act
        foo.DoSomething();
        //Assert
        foo.VerifyAllExpectations();
    }
