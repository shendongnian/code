    private static Dictionary<string, IAppAction> _handlers = ...;
    public static void Main()
	{
        string action = Console.ReadLine();
        // you should check the action actually exists in the Dictionary
        var handler = _handlers[action];
 
        // and then run it:
        Console.WriteLine(handler.Run(someData, otherData));
    }
