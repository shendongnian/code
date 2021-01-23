    var mock = new Mock<IFoo>();
    var calls = 0;
    mock.Setup(foo => foo.GetCountThing())
        .Returns(() => calls)
        .Callback(() =>
            {
                calls++;
                if (calls > 1)
                {
                    throw new InvalidOperationException("foo");
                }
            });
    Console.WriteLine(mock.Object.GetCountThing());
    Console.WriteLine(mock.Object.GetCountThing());
