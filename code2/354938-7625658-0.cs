    int paramA = 1;
    string paramB = "foo";
    var myThread = new Thread(() => SomeFunc(paramA, paramB));
    myThread.Start();
    public void SomeFunc(int paramA, string paramB)
    {
      // Do something...
    }
