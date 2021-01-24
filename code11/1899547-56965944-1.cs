csharp
var client = new SshClient("example.com", "username", "password");
client.Connect();
SshCommand command = client.CreateCommand("grep pattern file");
IAsyncResult result = command.BeginExecute();
using (var outputReader = new StreamReader(command.OutputStream))
using (var extendedReader = new StreamReader(command.ExtendedOutputStream))
{
    int read = 0;
    while (read < 10240)
    {
        string s;
        s = outputReader.ReadToEnd();
        read += s.Length;
        Console.Write(s);
        s = extendedReader.ReadToEnd();
        read += s.Length;
        Console.Write(s);
    }
}
command.CancelAsync();
---
Also, you can use `-m` switch to stop [`grep`](https://linux.die.net/man/1/grep) after certain number of matches.
