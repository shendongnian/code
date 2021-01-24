    private int _size;
    static void Main(string[] args)
    {                   
        //Get the value from user first
        _size = Convert.ToInt32(Console.Readline());
        //Execute the first draw
        ExecMain(_size);
        // Start the timer
        var t = new Timer(TimerCallback, null, 0, 2000);
        // Prevent the app from closing
        Console.ReadLine();
    }
    private static void TimerCallback(Object o)
    {            
        Console.Clear();
        ExecMain(_size);  //This is where i want to to add a "int x = Convert.ToInt32(Console.ReadLine());"
    }                 
