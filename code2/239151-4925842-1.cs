    public void MyFunc()
    {
      using (LogicalOperation.OperationStack.Push("MyFunc"))
      {
        MyOtherFunc();
      }
    }
    public void MyOtherFunc()
    {
      using (LogicalOperation.OperationStack.Push("MyOtherFunc"))
      {
        MyFinalFunc();
      }
    }
    public void MyFinalFunc()
    {
      using (LogicalOperation.OperationStack.Push("MyFinalFunc"))
      {
        Console.WriteLine("Hello");
      }
    }
