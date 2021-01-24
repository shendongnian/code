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
