    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    for (.......)
    {
    }
    stopWatch.Stop();
    TimeSpan ts = stopWatch.Elapsed;
    textbox1.Text = ts.TotalMilliseconds.ToString();
