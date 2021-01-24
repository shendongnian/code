    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    namespace ConsoleApplication1
    {
        class Program
        {
            public class UdpState
            {
                public UdpClient u;
                public IPEndPoint e;
                public string receivedMessage;
                // Size of receive buffer.  
                public const int BufferSize = 256;
                // Receive buffer.  
                public byte[] buffer = new byte[BufferSize];  
            }
            public static ManualResetEvent receiveDone = new ManualResetEvent(false);
            public static void Main()
    	    {
                string ip = "172.0.0.1";
                int port = 11111;
          
                IPAddress iotAddress =  IPAddress.Parse(ip);
                IPEndPoint iotEndpoint = new IPEndPoint(iotAddress, port);
                byte[] bytes = Encoding.UTF8.GetBytes("Hello World");
                UdpState state = new UdpState();
                try {
                    using (UdpClient client = new UdpClient(0, AddressFamily.InterNetwork)) {
                        client.Connect(iotEndpoint);
                        state.e = iotEndpoint;
                        state.u = client;
                        //  await the response of the IoT device
                        client.BeginReceive(new AsyncCallback(ReceiveCallback), state);
                        client.BeginSend(bytes, bytes.Length, iotEndpoint, new AsyncCallback(SendCallback), client); 
     
                        receiveDone.WaitOne();
                        var response = state.receivedMessage;
                    }
                } catch {
                    //  Ignore
                }
    	    }
            public static void ReceiveCallback(IAsyncResult ar)
            {
                UdpState state = ar.AsyncState as UdpState;
                UdpClient u = state.u;
                IPEndPoint e = state.e;
                state.buffer = u.EndReceive(ar, ref e);
                state.receivedMessage = Encoding.ASCII.GetString(state.buffer);
                receiveDone.Set();
             }
            private static void SendCallback(IAsyncResult ar)
            {
                try
                {
                    // Retrieve the socket from the state object.  
                    UdpClient  client = ar.AsyncState as UdpClient ;
                    // Complete sending the data to the remote device.  
                    int bytesSent = client.EndSend(ar);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }  
        }
    }
