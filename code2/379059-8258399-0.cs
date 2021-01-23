    [Test]
    public void Test()
    {
       _dependency.BackToRecord();
       _dependency.Expect(_ => _.GetValue).Return(2);
       _dependency.Replay();
       var value = _systemUnderTest.GetValueFromDependency();
       value.ShouldBe(2);   // Fails  says it's 1
    }
