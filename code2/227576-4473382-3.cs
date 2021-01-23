    [Test]
    public void Expect_AddCountryCall()
    { 
        var mock = new Mock<IService>();
        var x = new X(mock.Object).DoSomething(" .. ");
        mock.Verify(x => x.DoSomething("..");
    }
