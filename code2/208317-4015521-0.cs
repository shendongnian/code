    //really dodgy code
    public void PassMeAMethod(string text, Action method)
    {
      DoSomething(text);
      method();
      Foo();
    }
    
    // Elsewhere...
    
    public static void Main(string[] args)
    {
        PassMeAMethod("foo", () =>
            {
                // Method definition here.
            }
        );
    
        // Or, if you have an existing method in your class, I believe this will work
        PassMeAMethod("bar", this.SomeMethodWithNoParams);
    }
