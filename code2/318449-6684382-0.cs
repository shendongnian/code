    lock(typeof MyWebServiceClass)
    {
      if (ThirdPartyApiThatAcceptsTimeout(TimeSpan.FromMinutes(5)))
      {
        // The call was successful so proceed.
      }
      else
      {
        // The call timed out so bail out.
        return;
      }
    }
