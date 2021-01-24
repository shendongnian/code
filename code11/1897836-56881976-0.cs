lang-csharp
public static async Task< byte[] > ReceiveAsync( byte[] datagram )
{
    using ( var client = new UdpClient( 5555 ) )
    {
        client.Client.ReceiveTimeout = 200;
        await client.SendAsync( datagram, datagram.Length, "10.0.0.50", 5555 );
        var buffer = await client.ReceiveAsync();
        return buffer.Buffer;
    }
}
Thanks!
