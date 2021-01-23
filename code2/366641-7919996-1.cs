    var mock = new Mock<IFoo>();
    var calls = 0;
    mock.Setup(foo => foo.GetCountThing())
        .Returns(() => calls)
        .Callback(() =>
            {
                calls++;
                if (calls == 1)
                {
                    throw new InvalidOperationException("foo");
                }
            });
    try
    {
        Console.WriteLine(mock.Object.GetCountThing());
    }
    catch (InvalidOperationException)
    {
        Console.WriteLine("Got exception");
    }
    Console.WriteLine(mock.Object.GetCountThing());
