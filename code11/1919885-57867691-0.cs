 csharp
void Main()
{
    var scheduled = Schedule(
        TimeSpan.FromSeconds(1),
        () => Console.WriteLine($"The current time is: {DateTime.Now}"));
    
    Console.ReadLine();
    // Dispose will stop the scheduled action
    scheduled.Dispose();
}
public IDisposable Schedule<T>(TimeSpan interval, Func<T> func)
    => Observable.Interval(interval).Subscribe(_ => func());
public IDisposable Schedule(TimeSpan interval, Action action)
    => Observable.Interval(interval).Subscribe(_ => action());
