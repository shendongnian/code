C#
public static Task<int> WaitForExitedAsync(this Process process)
{
  var tcs = new TaskCompletionSource<int>();
  EventHandler handler = null;
  handler = (_, __) =>
  {
    process.Exited -= handler;
    tcs.TrySetResult(process.ExitCode);
  };
  process.Exited += handler;
  return tcs.Task;
}
However, this code has a few caveats:
 1. You must set `Process.EnableRaisingEvents` to `true` before the process starts.
 2. You must call `WaitForExitedAsync` before the process starts.
 3. When `Exited` is raised, that does *not* mean that the stdout/stderr streams are finished. The only way to flush those streams is to call `WaitForExit` (after the process has exited). Not exactly intuitive.
For simplicity, you may just want to call `WaitForExit` on a background thread instead. That would use an extra unnecessary thread, but for a GUI app, that isn't critical.
In your code, you can push `CaptureFrame` off to a background thread:
C#
private async void BtnStartCapture_Click(object sender, RoutedEventArgs e)
{
  for (int i = 1; i <= CaptureSettings.NoOfFrames; i++)
  {
    String currentFile;
    if (CaptureSettings.CkBoard1 == true)
    {
      currentFile = await Task.Run(() => CaptureSettings.CaptureFrame(1, i));
      fileNames.Add(currentFile);
    }
    if (CaptureSettings.CkBoard2 == true)
    {
      currentFile = await Task.Run(() => CaptureSettings.CaptureFrame(2, i));
      fileNames.Add(currentFile);
    }
  }
}
Note that [`async void` is used here *only* because this is an event handler][1]. Normally, you should avoid `async void`.
> How do I prevent a button from being clicked again until it finishes?
One common pattern is to disable the button while it is running, as such:
C#
private async void BtnStartCapture_Click(object sender, RoutedEventArgs e)
{
  BtnStartCapture.Enabled = false;
  try
  {
    for (int i = 1; i <= CaptureSettings.NoOfFrames; i++)
    {
      String currentFile;
      if (CaptureSettings.CkBoard1 == true)
      {
        currentFile = await Task.Run(() => CaptureSettings.CaptureFrame(1, i));
        fileNames.Add(currentFile);
      }
      if (CaptureSettings.CkBoard2 == true)
      {
        currentFile = await Task.Run(() => CaptureSettings.CaptureFrame(2, i));
        fileNames.Add(currentFile);
      }
    }
  }
  finally
  {
    BtnStartCapture.Enabled = true;
  }
}
> How do I cancel?
[Cancellation in .NET follows a standard pattern][2]. The code being canceled observes a `CancellationToken`, which can be set from a `CancellationTokenSource`. Each `CancellationTokenSource` is a way to cancel the operation, but it can only be used once. So in this case, you want a new `CancellationTokenSource` each time the operation begins.
You *could* interpret a cancellation request as a kill request for your external process, but in your case I think it would be better to interpret the cancellation request as "let the current external process finish; just don't capture the next frame". I'm thinking this is better because the external process communicates with a hardware device (which we don't want to get into an unexpected state), and because it's fairly fast.
C#
private CancellationTokenSource _cts;
private async void BtnStartCapture_Click(object sender, RoutedEventArgs e)
{
  _cts = new CancellationTokenSource();
  var token = _cts.Token;
  BtnStartCapture.Enabled = false;
  BtnCancelCapture.Enabled = true;
  try
  {
    for (int i = 1; i <= CaptureSettings.NoOfFrames; i++)
    {
      token.ThrowIfCancellationRequested();
      String currentFile;
      if (CaptureSettings.CkBoard1 == true)
      {
        currentFile = await Task.Run(() => CaptureSettings.CaptureFrame(1, i));
        fileNames.Add(currentFile);
      }
      if (CaptureSettings.CkBoard2 == true)
      {
        currentFile = await Task.Run(() => CaptureSettings.CaptureFrame(2, i));
        fileNames.Add(currentFile);
      }
    }
  }
  catch (OperationCanceledException)
  {
    // TODO: decide what to do here - clear fileNames? Display a message? Nothing?
  }
  finally
  {
    BtnStartCapture.Enabled = true;
    BtnCancelCapture.Enabled = false;
  }
}
private void BtnCancelCapture_Click(object sender, RoutedEventArgs e)
{
  _cts.Cancel();
}
  [1]: https://msdn.microsoft.com/en-us/magazine/jj991977.aspx
  [2]: https://docs.microsoft.com/en-us/dotnet/standard/threading/cancellation-in-managed-threads
