    static void Main(string [] args)
    {
        DateTime? startDate = null;
        if(args.length>1) 
        {
            DateTime.TryParse(args[0], out startDate);
        }
        if(startDate.HasValue && DateTime.Now<startDate.Value)
        {
            System.Threading.Timer timer = new System.Threading.Timer(new TimerCallback(StartProgram));
            timer.Change(startDate.Value.Substract(DateTime.Now).TotalMilliseconds, Timeout.Infinite);
        }
        else
            StartProgram();
    }
    private static void StartProgram()
    {
        Console.WriteLine("Started");
        //rest of you code
    }
