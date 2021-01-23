    this.MyFuncToCallFrmApp = new MyFunctionDelegate(PrintValues);
    // the method I'm mapping has a valid signature for the delegate I'm mapping to:
    public void PrintValues(int some, string args)
    {
      Console.WriteLine(string.Format("Some = {0} & Args = {1}", some.ToString(), args));
    }
