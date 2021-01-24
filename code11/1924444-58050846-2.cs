csharp
using System.Diagnostics;
private static void StartProcess(string exeName, string parameter)
{
    var process = new Process();
    process.StartInfo.FileName = exeName; 
    process.StartInfo.Arguments = parameter;
    process.EnableRaisingEvents = true;
    process.Start();
}
Then call it like
csharp
StartProcess("exename.exe", fileParameter);
