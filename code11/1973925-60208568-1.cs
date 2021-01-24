c#
var serverProcess = Process.Start(new ProcessStartInfo
{
    FileName = Path.GetFileName(serverpath),
    Arguments = launch,
    UseShellExecute = false
});
while (Console.ReadLine() != "exit")
{
    Thread.Sleep(500);
}
serverProcess.Close();
