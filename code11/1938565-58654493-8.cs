    static void Test()
    {
      string[] toys = { "car", "bat-mask", "halloween-toys", "marvel-toys", "transformer" };
      var list = toys.customExtensionMethods("car", 1);
      foreach ( var item in list )
        Console.WriteLine(item);
    }
