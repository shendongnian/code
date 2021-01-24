`c#
static void Main(string[] args)
{
   var cts = new CancellationTokenSource(2000);   
   var task = Task.Run(() => RunTask(cts.Token), cts.Token);
   await task;
}
public static void RunTask(CancellationToken token)
{
   while (!token.IsCancellationRequested)
   {
     Console.WriteLine("in while");
   }
}
`
