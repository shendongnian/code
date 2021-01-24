using System.Diagnostics;
//...
void StopwatchUsingMethod()
{
  //A: Setup and stuff you don't want timed
  var timer = new Stopwatch();
  timer.Start();
  //B: Run stuff you want timed
  timer.Stop();
  TimeSpan timeTaken = timer.Elapsed;
  string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff"); 
  //Look up timespan.ToString() for details on the formatting
}
If I understand your code correctly, you want to put everything up to and including the first `sdk.Display();` line in the A section and only put the call to Solve in the B section, so something like
static void Main(string[] args)
{
  //...
  sdk.Display();
  var timer = new Stopwatch();
  timer.Start();
  sdk.Solve(sdk.NextAvailableCell(), new Point());
  timer.Stop();
  Console.WriteLine("\n\n\nSolved Grid"); 
  //...you can use the time taken here
}
