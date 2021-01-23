    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    namespace SocketServer
    {
        class Connection
        {
            public Socket Socket { get; private set; }
            public byte[] Buffer { get; private set; }
            public Encoding Encoding { get; private set; }
            public Connection(Socket socket)
            {
                this.Socket = socket;
                this.Buffer = new byte[2048];
                this.Encoding = Encoding.UTF8;
            }
            public void WaitForNextString(AsyncCallback callback)
            {
                this.Socket.BeginReceive(this.Buffer, 0, 4, SocketFlags.None, callback, this);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Connection connection;
                using (Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    listener.Bind(new IPEndPoint(IPAddress.Loopback, 6767));
                    listener.Listen(1);
                    Console.WriteLine("Listening for a connection.  Press any key to end the session.");
                    connection = new Connection(listener.Accept());
                    Console.WriteLine("Connection established.");
                }
                connection.WaitForNextString(ReceivedString);
                Console.ReadKey();
            }
            static void ReceivedString(IAsyncResult asyncResult)
            {
                Connection connection = (Connection)asyncResult.AsyncState;
                int bytesReceived = connection.Socket.EndReceive(asyncResult);
                if (bytesReceived > 0)
                {
                    int length = BitConverter.ToInt32(connection.Buffer, 0);
                    byte[] buffer;
                    if (length > connection.Buffer.Length)
                        buffer = new byte[length];
                    else
                        buffer = connection.Buffer;
                    int index = 0;
                    int remainingLength = length;
                    do
                    {
                        bytesReceived = connection.Socket.Receive(buffer, index, remainingLength, SocketFlags.None);
                        index += bytesReceived;
                        remainingLength -= bytesReceived;
                    }
                    while (bytesReceived > 0 && remainingLength > 0);
                    if (remainingLength > 0)
                    {
                        Console.WriteLine("Connection was closed before entire string could be received");
                    }
                    else
                    {
                        Console.WriteLine(connection.Encoding.GetString(buffer, 0, length));
                    }
                    connection.WaitForNextString(ReceivedString);
                }
            }
        }
    }
