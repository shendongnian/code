 xml
<PackageReference Include="Pipelines.Sockets.Unofficial" Version="2.0.22" />
(adding this will automatically add all the other pieces you need)
 c#
using Pipelines.Sockets.Unofficial;
using System;
using System.IO.Pipelines;
using System.Net;
using System.Text;
using System.Threading.Tasks;
static class Program
{
    static async Task Main()
    {
        var endpoint = new IPEndPoint(IPAddress.Loopback, 9042);
        Console.WriteLine("[server] Starting server...");
        using (var server = new MyServer())
        {
            server.Listen(endpoint);
            Console.WriteLine("[server] Starting client...");
            Task reader;
            using (var client = await SocketConnection.ConnectAsync(endpoint))
            {
                reader = Task.Run(() => ShowIncomingDataAsync(client.Input));
                await WriteAsync(client.Output, "hello");
                await WriteAsync(client.Output, "world");
                Console.WriteLine("press [return]");
                Console.ReadLine();
            }
            await reader;
            server.Stop();
        }
    }
    private static async Task ShowIncomingDataAsync(PipeReader input)
    {
        try
        {
            while (true)
            {
                var read = await input.ReadAsync();
                var buffer = read.Buffer;
                if (buffer.IsEmpty && read.IsCompleted) break; // EOF
                Console.WriteLine($"[client] Received {buffer.Length} bytes; marking consumed");
                foreach (var segment in buffer)
                {   // usually only one segment, but can be more complex
                    Console.WriteLine("[client] " + Program.GetAsciiString(segment.Span));
                }
                input.AdvanceTo(buffer.End); // "we ate it all"
            }
        }
        catch { }
    }
    private static async Task WriteAsync(PipeWriter output, string payload)
    {
        var bytes = Encoding.ASCII.GetBytes(payload);
        await output.WriteAsync(bytes);
    }
    internal static unsafe string GetAsciiString(ReadOnlySpan<byte> span)
    {
        fixed (byte* b = span)
        {
            return Encoding.ASCII.GetString(b, span.Length);
        }
    }
}
class MyServer : SocketServer
{
    protected override Task OnClientConnectedAsync(in ClientConnection client)
        => RunClient(client);
    private async Task RunClient(ClientConnection client)
    {
        Console.WriteLine($"[server] new client: {client.RemoteEndPoint}");
        await ProcessRequests(client.Transport);
        Console.WriteLine($"[server] ended client: {client.RemoteEndPoint}");
    }
    private async Task ProcessRequests(IDuplexPipe transport)
    {
        try
        {
            var input = transport.Input;
            var output = transport.Output;
            while (true)
            {
                var read = await input.ReadAsync();
                var buffer = read.Buffer;
                if (buffer.IsEmpty && read.IsCompleted) break; // EOF
                Console.WriteLine($"[server] Received {buffer.Length} bytes; returning it, and marking consumed");
                foreach (var segment in buffer)
                {   // usually only one segment, but can be more complex
                    Console.WriteLine("[server] " + Program.GetAsciiString(segment.Span));
                    await output.WriteAsync(segment);
                }
                input.AdvanceTo(buffer.End); // "we ate it all"
            }
        }
        catch { }
    }
}
I **could** write this with raw sockets, but it would take a lot more code to show best practice and avoid problems - all of that ugliness is already hidden inside "pipelines".
Output:
[server] Starting server...
[server] Starting client...
[server] new client: 127.0.0.1:63076
press [return]
[server] Received 5 bytes; returning it, and marking consumed
[server] hello
[server] Received 5 bytes; returning it, and marking consumed
[client] Received 5 bytes; marking consumed
[client] hello
[server] world
[client] Received 5 bytes; marking consumed
[client] world
