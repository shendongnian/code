    lock(typeof MyWebServiceClass)
    {
      var thread = new Thread(
        () =>
        {
          ThirdPartyApiThatCouldBlockIndefinitely();
        });
      thread.Start();
      if (thread.Join(TimeSpan.FromMinutes(5))
      {
        // The call was successful so proceed.
      }
      else
      {
        // The call timed out so bail out.
        thread.Abort();
        return;
      }
    }
