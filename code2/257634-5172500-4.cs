    int i = 0;
    while (!p1.HasExited && i < maxWaits)
    {
        Thread.Sleep(delay);
        i++;
    }
    sw.Write(sr.ReadToEnd());
    //Kill process if running:
    if (!p1.HasExited)
    {
        try { p1.Kill(); }
        catch { }
    }
