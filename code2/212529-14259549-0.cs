    [Test]
    public void Test()
    {
        var fakedInterface = MockRepository.GenerateMock<ISite>();
        // Stub property setter and call own lambda when invoked.
        fakedInterface.BackToRecord();
        Expect.Call(fakedInterface.Name).SetPropertyAndIgnoreArgument().WhenCalled(a =>
        {
            Assert.That(a.Arguments.Length, Is.EqualTo(1));
            Assert.That(a.Arguments[0], Is.EqualTo("abc"));
            // Stub property getter with provided value.
            fakedInterface.Stub(x => x.Name).Return((String)a.Arguments[0]);
        });
        fakedInterface.Replay();
        // Set the property (and let our above lambda be invoked)
        fakedInterface.Name = "abc";
        // Get the property (the value that was freshly stubbed within the lamba.
        var result = fakedInterface.Name;
        Assert.That(result, Is.EqualTo("abc"));
    }
