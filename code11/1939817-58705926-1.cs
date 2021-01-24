progressBar.Value = 0;
progressBar.Step = 1;
progressBar1.Maximum = 500;
progressBar.Refresh();
Cursor = Cursors.WaitCursor;
try
{
  for( int i = 1; i <= progressBar.Maximum; i++ )
  {
    // do process
    progressBar.PerformStep();
    progressBar.Refresh();
    Thread.Sleep(10);
  }
}
finally
{
  Cursor = Cursors.Default;
}
No need to Sleep unless you want to reduce the speed of the process.
