    [ConditionalAttribute("DEBUG")]
    public static void MyLovelyDebugInfoMethod(string message)
    {
        Console.WriteLine("This message was brought to you by your debugger : ");
        Console.WriteLine(message);
    }
    
