    using System;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    
    namespace ClientServer
    {
        class ClientServerProgram
        {    
           public static void SendHeader(string sMIMEHeader, int iTotBytes, string sStatusCode, ref Socket mySocket)
          {
            String sBuffer = "";
            // if Mime type is not provided set default to text/html
            if (sMIMEHeader.Length == 0)
            {
                sMIMEHeader = "text/html";  // Default Mime Type is text/html
            }
            sBuffer = sBuffer + "HTTP/1.1" + sStatusCode + "\r\n";
            sBuffer = sBuffer + "Server: cx1193719-b\r\n";
            sBuffer = sBuffer + "Content-Type: " + sMIMEHeader + "\r\n";
            sBuffer = sBuffer + "Accept-Ranges: bytes\r\n";
            sBuffer = sBuffer + "Content-Length: " + iTotBytes + "\r\n\r\n";
            Byte[] bSendData = Encoding.ASCII.GetBytes(sBuffer);
            mySocket.Send(Encoding.ASCII.GetBytes(sBuffer),Encoding.ASCII.GetBytes(sBuffer).Length, 0);
            Console.WriteLine("Total Bytes : " + iTotBytes.ToString());
          }
    
            public static void ReceiveCallback(IAsyncResult AsyncCall)
            {            
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                string messageString = "I am a little busy, come back later!";
                Byte[] message = encoding.GetBytes(messageString);
    
                Socket listener = (Socket)AsyncCall.AsyncState;
                Socket client = listener.EndAccept(AsyncCall);
                Console.WriteLine("Received Connection from {0}", client.RemoteEndPoint);
                SendHeader("text/html", message.Length, "202 OK", ref client);
                client.Send(message);
                Console.WriteLine("Ending the connection");
                client.Close();
                listener.BeginAccept(new AsyncCallback(ReceiveCallback), listener);
            }
    
        public static void Main()
        {
           IPAddress localAddress = IPAddress.Parse("192.0.127.1");
           Socket listenSocket = new Socket(AddressFamily.InterNetwork,  SocketType.Stream, ProtocolType.Tcp);
           IPEndPoint ipEndpoint = new IPEndPoint(localAddress, 8080);
           listenSocket.Bind(ipEndpoint);
           listenSocket.Listen(1);
           listenSocket.BeginAccept(new AsyncCallback(ReceiveCallback), listenSocket);
           while (true)
           {                    
              Console.WriteLine("Waiting....");
              Thread.Sleep(1000);
           }                
        }
    }
