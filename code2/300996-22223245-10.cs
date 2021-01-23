    using System.Diagnostics;
    private static void NOP(double durationSeconds)
    {
        var durationTicks = Math.Round(durationSeconds * Stopwatch.Frequency);
        var sw = Stopwatch.StartNew();
        while (sw.ElapsedTicks < durationTicks)
        {
        }
    }
