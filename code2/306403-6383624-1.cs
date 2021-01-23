    try
    {//Empty try block
    }
    finally
    {
      //put all your code in the finally clause to fool thread abortion
      using(var disposable=new ClassThatShouldBeDisposed())
      {
      ...
      }
    }
