    //First I create the default stub with a default value
    var foo = MockRepository.GenerateMock<IFoo>();
    foo.Expect(x => x.TheValue).Return(1);
    //Somewhere else in the code I override the stubbed value
    foo.Expect(x => x.TheValue).Return(2);
    Assert.AreEqual(1, foo.TheValue);
    Assert.AreEqual(2, foo.TheValue);
