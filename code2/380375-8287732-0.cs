    try
    {
      throw new Derived1();
    }
    catch (Exceptionz)
    {
      Console.WriteLine("Caught Derived 1");
    }
    
    try
    {
      throw new Derived2();
    }
    catch (Exceptionz)
    {
      Console.WriteLine("Caught Derived 2");
    }
