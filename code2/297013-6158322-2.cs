    public int MyLongOperation(int x, int y)
    {
        Thread.Sleep(10000);
        return x + y;
    }
    public void CallLongOperation()
    {
        Func<int, int, int> func = MyLongOperation;
        func.BeginInvoke(5, 7, MyCallback, "Expected result: " + 12);
        Console.WriteLine("Called BeginInvoke");
        func.BeginInvoke(11, 22, MyCallback, "Expected result: " + 33);
        Console.WriteLine("Press ENTER to continue");
        Console.ReadLine();
    }
    void MyCallback(IAsyncResult asyncResult)
    {
        Func<int, int, int> func = (Func<int, int, int>)((System.Runtime.Remoting.Messaging.AsyncResult)asyncResult).AsyncDelegate;
        string expectedResult = (string)asyncResult.AsyncState;
        int result = func.EndInvoke(asyncResult);
        Console.WriteLine("Result: {0} - {1}", result, expectedResult);
    }
