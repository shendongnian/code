    try
    {
      Console.WriteLine("try1");
      // throw new ArgumentNullException();
      // Console.WriteLine(((string)null).Length); // Will also throw exception
    }
    catch(ArgumentNullException e1)
    {
      Console.WriteLine("catch1");
      Console.WriteLine(e1.ToString());
      // throw;
      // throw new ArgumentNullException();
      // Console.WriteLine(((string)null).Length); // Will also throw exception
    }
    catch(Exception e1a)
    {
      Console.WriteLine("catch1a");
      Console.WriteLine(e1a.ToString());
      // throw;
      // throw new ArgumentNullException();
      // Console.WriteLine(((string)null).Length); // Will also throw exception
    }
    finally
    {
      Console.WriteLine("finally1");
      // throw new ArgumentNullException();
      // Console.WriteLine(((string)null).Length); // Will also throw exception
    }
    try
    {
      Console.WriteLine("try2");
      // throw new ArgumentNullException();
      // Console.WriteLine(((string)null).Length); // Will also throw exception
    }
    catch(ArgumentNullException e2)
    {
      Console.WriteLine("catch2");
      Console.WriteLine(e2.ToString());
      // throw;
      // throw new ArgumentNullException();
      // Console.WriteLine(((string)null).Length); // Will also throw exception
    }
    catch(Exception e2a)
    {
      Console.WriteLine("catch2a");
      Console.WriteLine(e2a.ToString());
      // throw;
      // throw new ArgumentNullException();
      // Console.WriteLine(((string)null).Length); // Will also throw exception
    }
    finally
    {
      Console.WriteLine("finally2");
      // throw new ArgumentNullException();
      // Console.WriteLine(((string)null).Length); // Will also throw exception
    }
