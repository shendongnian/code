C#
private async void Form1_Load(object sender, EventArgs e)
{
  while (true)
  {
    int c = await Task.Run(() => check());
    label7.Text = c.ToString();
  }
}
Alternatively, if you wanted the infinite loop in your background code, you could use  `IProgress<T>` to report progress to the UI thread:
C#
private Task CheckForever(IProgress<int> progress)
{
  while (true)
  {
    var c = check();
    progress?.Report(c);
  }
}
private async void Form1_Load(object sender, EventArgs e)
{
  var progress = new Progress<int>(c => label7.Text = c.ToString());
  await CheckForever(progress);
}
Note that `Task.Run` code is always cleaner, easier to maintain, and more type-safe than `BackgroundWorker` code.
