    long ticks1 = tsp1.Ticks;
    long ticks2 = tsp2.Ticks;
    long remainder;
    long count = Math.DivRem(ticks1, ticks2, out remainder);
    TimeSpan remainderSpan = TimeSpan.FromTicks(remainder);
    Console.WriteLine("tsp1/tsp2 = {0}, remainder {1}", count, remainderSpan);
