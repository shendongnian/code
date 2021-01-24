    public (int SomeVal, string Another) authenticate(string un, string pw)
    {
        ...
        return (2,"yay");
    }
    
    ...
    
    var result = testcon.authenticate("username", "password")); 
    Console.WriteLine(result.SomeVal);
    Console.WriteLine(result.Another);
