    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration().WriteTo.File("voltage.log").CreateLogger();
        var line = "IDN = {0}, DCV = {1}";
        var rnd = new Random();
        for (int i = 0; i < 100; i++)
        {
            var idn = rnd.Next(0, 100);
            var dcv = rnd.NextDouble();
            Log.Information(string.Format(line, idn, dcv));
        }
    }
