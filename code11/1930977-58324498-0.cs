    static void Main(string[] args)
    {
        Dictionary<string, object> toLog = new Dictionary<string, object>();
        toLog.Add("today", DateTime.Today);
        toLog.Add("tomorrow", DateTime.Today.AddDays(1));
        Log(toLog );
        Console.ReadKey();
    }
    public static void Log(Dictionary<string, object> toLog)
    {
        foreach (var kvp in toLog)
        {
            Console.WriteLine(kvp.Key);   
            Console.WriteLine(kvp.Value);
        }
    }
