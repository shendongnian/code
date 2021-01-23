    var input = "5:06";
    
    TimeSpan ts;
    
    var parseSuccessful = TimeSpan.TryParse(input, out ts);
    
    if  (parseSuccessful)
    {
        if (input.Count(c => c == ':') == 1)
        {
            // TryParse parsed this as hh:mm but we want it to mean mm:ss
            // so scale appropriately
            ts = new TimeSpan(ts.Ticks / 60);
        }
    
        Console.WriteLine(ts.ToString(@"hh\:mm\:ss"));
    }
