    public class Example
    {
        static NetworkStream stream;
        static TcpClient client;
		public static void Main(String[] args)
            String message = String.Empty;
            //TCP connection
     Recon: Console.WriteLine("Connecting...");
            Int32 port = 3333;
            try
            {
                client = new TcpClient("ip.ip.ip.ip", port); //Try to connect
            }
            catch
            {
                Console.WriteLine("Problem while connecting!");
                Thread.Sleep(10000); //Waiting 10s before reconnect
                goto Recon;
            }
            Console.WriteLine("Connection established!\n");
            stream = client.GetStream();
            while (true)
            {
                //Buffer
                byte[] received_bytes = new Byte[1024];
                message = "";
                Console.WriteLine("Waiting to receive message...\n");
                Int32 bytes = stream.Read(received_bytes, 0, received_bytes.Length);
                message = System.Text.Encoding.GetEncoding("iso-8859-1").GetString(received_bytes, 0, bytes);
                if (bytes == 0) //If connection abort while reading
                {
                    Console.WriteLine("Connection failed!");
                    //Recconecting
                    goto Recon;
                }
                Console.WriteLine("Received message: " + message);
            }
        }
	}
