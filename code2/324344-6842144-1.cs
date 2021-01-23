    User u = new User();
    System.Console.WriteLine("u is User: " + (u is User));
    System.Console.WriteLine("u is Agent: " + (u is Agent));
    System.Console.WriteLine("u is Client: " + (u is Agent));
    // Should produce:
    // u is User: true
    // u is Agent: false
    // u is Client: false
    Agent a = new Agent();
    u = a;
    System.Console.WriteLine("u is User: " + (u is User));
    System.Console.WriteLine("u is Agent: " + (u is Agent));
    System.Console.WriteLine("u is Client: " + (u is Agent));
    // Should produce:
    // u is User: true
    // u is Agent: true
    // u is Client: false
    
