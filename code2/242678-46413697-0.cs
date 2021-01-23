    [Test]
    public void Answer_Question()
    {
        var ex = Assert.Throws<AggregateException>(() => Parallel.Invoke(
            () => Logging.WriteLog("abc"),
            () => Logging.WriteLog("123")
        ));
        // System.IO.IOException: The process cannot access the file 'C:\Logs\thread-safety-test.txt' because it is being used by another process.
        Console.Write(ex);
    }
