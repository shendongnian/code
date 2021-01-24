    public static void Main()
    { 
      var enumValue = Foo.Bar | Foo.Far; 
      Console.WriteLine(enumValue.HasMultipleFlags()); // Prints 'True'
    
      enumValue = Foo.Bar;
      Console.WriteLine(enumValue.HasMultipleFlags()); // Prints 'False'
    }
