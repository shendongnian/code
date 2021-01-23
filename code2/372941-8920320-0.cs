    sw = Stopwatch.StartNew();
    builder = new StringBuilder();
    for (int j = 0; j < max; j++)
    {
        builder.Clear();
        builder.Append("Your total is ");
        builder.Append("$500 ");
        builder.Append(DateTime.Now);
    }
    sw.Stop();
    Console.WriteLine("StringBuilder (clearing)\t: {0}ms", ((int)sw.ElapsedMilliseconds).ToString().PadLeft(6));
    sw = Stopwatch.StartNew();
    for (int i = 0; i < max; i++)
    {
        msg = "Your total is " + "$500" + DateTime.Now;
    }
    sw.Stop();
    Console.WriteLine("String + (one line)\t: {0}ms", ((int)sw.ElapsedMilliseconds).ToString().PadLeft(6));
