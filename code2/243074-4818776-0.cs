    var keyPressed = Observable.Create<ConsoleKey>(
        o =>
            {
                while (true)
                {
                    var consoleKeyInfo = Console.ReadKey(true);
                    o.OnNext(consoleKeyInfo.Key);
                }
            }
        );
    var paired = keyPressed
        .BufferWithCount(2)
        .Select(x => new {a = x[0], b = x[1]});
    paired.Subscribe(Console.WriteLine);
