    public static void GetStuff(string title, Action<int> action)
    {
       var value = 0;
       Console.WriteLine($"{title}: ");
       while(!int.TryParse(Console.ReadLine(), out value))
          Console.WriteLine($"You had one job! {title}: ");
       action(value);
    }
    
    
    ...
    
    // Assign to some property
    GetStuff("Age", value => AgeProperty = value);
    // assign to some variable
    GetStuff("Width", value => WidthVariable = value);
    // call some method
    GetStuff("Height", value => SomeMethod(value));
