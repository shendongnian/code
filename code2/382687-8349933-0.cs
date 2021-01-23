    TimeSpan start = new TimeSpan(42); // 42 ticks
    TimeSpan end = new TimeSpan(420000000);
    TimeSpan diff = end.Subtract(start);
    string ms = diff.Milliseconds.ToString();
    string sec = ((int)diff.TotalSeconds).ToString();
    Console.WriteLine(sec + ":" + ms);
