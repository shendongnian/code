C#
private void Calculate(int i)
{
  for (int j = 0; j != 10000; ++j)
    Math.Pow(i, i);
}
Currently, the UI thread is swamped with progress updates, so it doesn't have time to respond to user input.
If your real-world code is not easily split into larger chunks, you can use a rate-throttling `IProgress<T>` implementation like [one I wrote][1] when updating [my book][2]:
C#
public static class ObservableProgress
{
  public static (IObservable<T> Observable, IProgress<T> Progress) CreateForUi<T>(TimeSpan? sampleInterval = null)
  {
    var (observable, progress) = Create<T>();
    observable = observable.Sample(sampleInterval ?? TimeSpan.FromMilliseconds(100))
        .ObserveOn(SynchronizationContext.Current);
    return (observable, progress);
  }
  public static (IObservable<T> Observable, IProgress<T> Progress) Create<T>()
  {
    var progress = new EventProgress<T>();
    var observable = Observable.FromEvent<T>(handler => progress.OnReport += handler, handler => progress.OnReport -= handler);
    return (observable, progress);
  }
  private sealed class EventProgress<T> : IProgress<T>
  {
    public event Action<T> OnReport;
    void IProgress<T>.Report(T value) => OnReport?.Invoke(value);
  }
}
Usage:
C#
private async void run_Click(object sender, EventArgs e)
{
  cts = new CancellationTokenSource();
  var cancelToken = cts.Token;
  progressBar.Maximum = 100;
  progressBar.Step = 1;
  var (observable, progress) = ObservableProgress.CreateForUi<int>();
  try
  {
    using (observable.Subscribe(v => progressBar.Value = v))
      await Task.Run(() => { DoWork(progress, cancelToken); }, cts.Token);
  }
  catch (OperationCanceledException ex)
  {
    Console.WriteLine($"{nameof(OperationCanceledException)} thrown with message: {ex.Message}");
  }
  finally
  {
    cts = null;
  }
}
The rate-throttling `IProgress<T>` will throw away extra progress updates, only sending one progress update every 100ms to the UI thread, which it should easily be able to handle and remain responsive to user interaction.
  [1]: https://gist.github.com/StephenCleary/4248e50b4cb52b933c0d
  [2]: https://stephencleary.com/book/
