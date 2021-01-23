    var mocker = new AutoMoqer();
    mocker.GetMock<IDummyParameters>.Setup(x => x.SomeInt).Returns(1);
    mocker.GetMock<IDummyParameters>.Setup(x => x.SomeOtherInt).Returns(2);
    // notice how this code does not say anything about IFoo.
    // It is created automatically by AutoMoq
    var dummy = mocker.Create<Dummy>();
