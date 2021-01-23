    protected bool _skipConsoleInput = false;
    public static void Main(string[] args)
    {
         if(args != null && args.Count > 0 && args[0] == "SkipConsoleInputYo")
             _skipConsoleInput = true;
         loadFile();
         GetConsoleInput();
         foreach(var x in imgSet) { }
    }
    protected string GetConsoleInput()
    {
        if(_skipConsoleInput)
           return string.Empty;
        
        return Console.ReadLine();
    }
