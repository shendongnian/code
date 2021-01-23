    mock.Expect(theMock => theMock.IsBusy())
        .Return(true)
        .Repeat.Times(5);
    mock.Expect(theMock => theMock.IsBusy())
        .Return(false);
