    using System;
    using Microsoft.SPOT.Hardware;
    private static long _TicksPerNanoSecond = TimeSpan.TicksPerMillisecond/1000;
    private void Wait(long nanoseconds)
    {
        var then = Utility.GetMachineTime().Ticks;
        while (true)
        {
            var now = Utility.GetMachineTime().Ticks;
            if ((now - then) > nanoseconds * _TicksPerNanoSecond) break;
        }
    }
