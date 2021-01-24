    using System.Net; 
    using System.Net.Sockets;
    
     class Program
    {
        static int port = 8005; // your port
        static void Main(string[] args)
        {
            // get address to run socket
            var ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
             
            // create socket
            var listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // binding
                listenSocket.Bind(ipPoint);
 
                // start listen
                listenSocket.Listen(10);
 
                Console.WriteLine("Server is working");
 
                while (true)
                {
                    Socket handler = listenSocket.Accept();
                    // recieve message
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; // quantity of received bytes 
                    byte[] data = new byte[256]; // data buffer
 
                    do
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (handler.Available>0);
 
                    Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + builder.ToString());
 
                    // send response
                    string message = "your message recieved";
                    data = Encoding.Unicode.GetBytes(message);
                    handler.Send(data);
                    // close socket
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
