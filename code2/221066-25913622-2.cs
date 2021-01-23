    using System;
    using Microsoft.SPOT.Hardware;
    private static long _TicksPerMicroSecond = TimeSpan.TicksPerMillisecond/1000;
    private void Wait(long microseconds)
    {
        var then = Utility.GetMachineTime().Ticks;
        var ticksToWait = microseconds * _TicksPerNanoSecond;
        while (true)
        {
            var now = Utility.GetMachineTime().Ticks;
            if ((now - then) > ticksToWait) break;
        }
    }
