    System.Threading.Timer aTimer = new System.Threading.Timer(OnTimedEvent, null, 5000, 5000);
    private static void OnTimedEvent(Object stateInfo)
    {
        Console.WriteLine("Hi");
    }
