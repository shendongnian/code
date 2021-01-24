A
B
A
B
B
A
GC Collected
B
B
B
### Code
using System;
using System.Threading.Tasks;
class TimerExperiment
{
    System.Threading.Timer timer; 
    public TimerExperiment() {
        StartTimer("A"); // Not keeping this timer
        timer = StartTimer("B"); // Keeping this timer
    }
    static System.Threading.Timer StartTimer(string name) {
        return new System.Threading.Timer(_ =>
        {
            Console.WriteLine($"{name}");
        }, null, dueTime: TimeSpan.Zero, period: TimeSpan.FromSeconds(1));
    }
}
class Program
{
    static async Task Main(string[] args)
    {
        var withTimers = new TimerExperiment();
        await Task.Delay(TimeSpan.FromSeconds(2));
        GC.Collect();
        Console.WriteLine("GC Collected");
        Console.ReadLine();
    }
}
----
# Muddying the waters
`System.Threading.Timer`'s `Timer(TimerCallback callback)` constructor (the one that doesn't take the `dueTime` and others) uses `this` for `state` which means that the timer will keep a reference to itself and this means that it will survive garbage collection. 
 
public Timer(TimerCallback callback)
{
    (...)
    TimerSetup(callback, this, (UInt32)dueTime, (UInt32)period, ref stackMark);
}
## Example 2
Timer 'C' is created using `Timer(TimerCallback callback)` and it just keeps going.
### Output
A
B
C
A
B
C
GC Collected
B
C
C
B
B
C
### Code
class TimerExperiment
{
    System.Threading.Timer timerB;
    
    public TimerExperiment()
    {
        StartTimer("A"); // Not keeping this timer
        timerB = StartTimer("B"); // Keeping this timer
        StartTimer2("C"); // Not keeping this timer
    }
    static System.Threading.Timer StartTimer(string name) {
        return new System.Threading.Timer(_ =>
        {
            Console.WriteLine($"{name}");
        }, null, dueTime: Delay(name), period: TimeSpan.FromSeconds(1));
    }
    static System.Threading.Timer StartTimer2(string name)
    {
        //Create the timer using the constructor which only takes the callback
        var t = new System.Threading.Timer( _ => Console.WriteLine($"{name}"));
        t.Change(dueTime: Delay(name), period: TimeSpan.FromSeconds(1));
        return t;
    }
    static TimeSpan Delay(string name) 
            => TimeSpan.FromMilliseconds(Convert.ToInt64(name[0])*10);
}
class Program
{
    static async Task Main(string[] args)
    {
        var withTimers = new TimerExperiment();
        await Task.Delay(TimeSpan.FromSeconds(2));
        GC.Collect();
        Console.WriteLine("GC Collected");
        Console.ReadLine();
    }
}
