    try
    {
      DoStuff();
    }
    catch (Exception e)
    {
      throw new FaultException<MyCustomFault>(new MyCustomFault
                                                  {
                                                    Description = "Oh No!",
                                                    ErrorCode = 1234
                                                  });
    }
