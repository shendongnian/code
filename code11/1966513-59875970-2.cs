...
Console.WriteLine("Enter a request: ");
string req = Console.ReadLine();
LoopConnect();
        
byte[] buffer = Encoding.ASCII.GetBytes(req);
_clientSocket.Send(buffer,0,buffer.Length,SocketFlags.None);
_clientSocket.ReceiveTimeout = 10000;
...
This should ensure you open up a socket whenever you want to send a request.
In addition you might want to move the shutdown and close operations for the socket to a `finally` block at the end of the try catch being left with 
csharp
try
{
    var receivedBuffer = new byte[2048];
    int rec = _clientSocket.Receive(receivedBuffer, SocketFlags.None);
    byte[] data = new byte[rec];
    Array.Copy(receivedBuffer, data, rec);
    string result = Encoding.ASCII.GetString(data);
    Console.WriteLine("Received : " + result);
}
catch (SocketException se)
{
    if (se.SocketErrorCode == SocketError.TimedOut)
    {
        Console.WriteLine("TIMEOUT");
    }
}
finally
{
    _clientSocket.Disconnect(true);
}
