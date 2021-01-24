csharp
FluentFTP
System.Net
csharp
using (var client = new FtpClient("SERVERNAME"))
{
    client.Port = 990;
    client.EncryptionMode = FtpEncryptionMode.Implicit;
    client.Credentials = new NetworkCredential(@"USERNAME", @"PASSWORD");
    
    using (var cts = new CancellationTokenSource(TimeSpan.FromMinutes(5)))
    {
        await client.ConnectAsync(cts.Token);
        client.GetListing("/").Dump();
        await client.DisconnectAsync(cts.Token);
    }
}
