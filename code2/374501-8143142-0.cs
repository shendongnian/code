     Or if you know that your object that you are trying to dispose of Implements IDisposable
    why not do something like this
    StreamWriter streamWrt = null
    try
    {
    streamWrt = new StreamWrite();
    ... do some code here
    }
    catch (Exception ex)
    {
     Console.WriteLine(ex.Message)
    }
    Finally
    {
      if (streamWrt != null)
      {
        ((IDisposable)streamWrt).Dispose();
      }
    }
