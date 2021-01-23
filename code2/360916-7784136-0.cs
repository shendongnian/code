    namespace Consoleserver
    {
    class Program
    {
        static void Main(string[] args)
        {
            
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
        IPAddress ipAddress = ipHostInfo.AddressList[0];
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
        
        Socket listener = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp );
       
        try
        {
            listener.Bind(localEndPoint);
            listener.Listen(10);
           
            while (true)
            {
                Console.WriteLine("Waiting for a connection...");
           
                Socket handler = listener.Accept();
                Console.WriteLine("connected");
            }
            
        }
        catch { Console.WriteLine("error"); 
        }
      }
    }
