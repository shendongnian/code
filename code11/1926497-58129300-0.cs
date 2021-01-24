    public static T AskValue<T>(string name)
      where T : IConvertible
    {
      T result = default(T);
      bool isValid = false;
      if ( name == "" ) name = "Value";
      while ( !isValid )
      {
        Console.WriteLine($"{name}: ");
        try
        {
          result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
          isValid = true;
        }
        catch
        {
          Console.WriteLine("You entered a wrong value. Retry, please.");
        }
      }
      return result;
    }
