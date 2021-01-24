C#
private async Task RunBatchOCR(List<Printout> printouts, IProgress<int> progress)
{
  int counter = 0;
  progress?.Report(0);
  try
  {
    Parallel.ForEach(printouts, new ParallelOptions { CancellationToken = source.Token }, printout =>
    {
      printout.OcrHelper.runOCR(); //loads bitmap and extracts text
      var update = Interlocked.Increment(ref counter);
      progress?.Report(update);
      Console.WriteLine(update.ToString());
    });
  }
  catch (OperationCanceledException)
  {
    Console.WriteLine("Task was cancelled");
    cancelButton.Enabled = false;
  }
}
