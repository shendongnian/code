c#
public interface ITimed
{
    TimeSpan ExecutionTime { get; set; }
}
public class MethodResult<T> : ITimed
{
    public T Result { get; set; }
    public TimeSpan ExecutionTime { get; set; }
}
public class MethodTimer : IDisposable
{
    private readonly Stopwatch _StopWatch;
    private ITimed _result;
    public MethodTimer(ITimed result)
    {
        _result = result;
        _StopWatch = new Stopwatch();
        _StopWatch.Start();
    }
    public void Dispose()
    {
        _StopWatch.Stop();
        _result.ExecutionTime = _StopWatch.Elapsed;
        _result = null;
    }
}
Usage
c#
static MethodResult<int> TestMehodResult()
{
    var timedResult = new MethodResult<int>();
    using (var timer = new MethodTimer(timedResult))
    {
        timedResult.Result = 666;
        Thread.Sleep(1000);
    }
    return timedResult;
}
