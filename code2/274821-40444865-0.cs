    [ImmutableClass(Options = ImmutableClassOptions.EnableOperatorEquals)]
    class Person {
      private const int AgeDefaultValue = 18;
    
      public string FirstName { get; }
      public string LastName { get; }
      public int Age { get; }
    
      [ComputedProperty]
      public string FullName {
        get {
          return FirstName + " " + LastName;
        }
      }
    }
