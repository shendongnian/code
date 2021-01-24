    [Test] public void ToFuncForGivenActionInvokesAction()
    {
        // arrange
        bool invoked = false;
        Action action = () => invoked = true;
        // act
        var func = action.ToFunc();
        // assert
        func().Should().Be(Unit.Default);
        invoked.Should().BeTrue();
    }
