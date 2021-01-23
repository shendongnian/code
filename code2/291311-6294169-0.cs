    class ClientContext
    {
        public TcpClient Client;
        public Stream Stream;
        public byte[] Buffer = new byte[4];
        public MemoryStream Message = new MemoryStream();
    }
    class Program
    {
        static void OnMessageReceived(ClientContext context)
        {
            // process the message here
        }
        static void OnClientRead(IAsyncResult ar)
        {
            ClientContext context = ar.AsyncState as ClientContext;
            if (context == null)
                return;
            try
            {
                int read = context.Stream.EndRead(ar);
                context.Message.Write(context.Buffer, 0, read);
                int length = BitConverter.ToInt32(context.Buffer, 0);
                byte[] buffer = new byte[1024];
                while (length > 0)
                {
                    read = context.Stream.Read(buffer, 0, Math.Min(buffer.Length, length));
                    context.Message.Write(buffer, 0, read);
                    length -= read;
                }
                OnMessageReceived(context);
            }
            catch (System.Exception)
            {
                context.Client.Close();
                context.Stream.Dispose();
                context.Message.Dispose();
                context = null;
            }
            finally
            {
                if (context != null)
                    context.Stream.BeginRead(context.Buffer, 0, context.Buffer.Length, OnClientRead, context);
            }
        }
        static void OnClientAccepted(IAsyncResult ar)
        {
            TcpListener listener = ar.AsyncState as TcpListener;
            if (listener == null)
                return;
            try
            {
                ClientContext context = new ClientContext();
                context.Client = listener.EndAcceptTcpClient(ar);
                context.Stream = context.Client.GetStream();
                context.Stream.BeginRead(context.Buffer, 0, context.Buffer.Length, OnClientRead, context);
            }
            finally
            {
                listener.BeginAcceptTcpClient(OnClientAccepted, listener);
            }
        }
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(new IPEndPoint(IPAddress.Any, 20000));
            listener.Start();
            listener.BeginAcceptTcpClient(OnClientAccepted, listener);
            Console.Write("Press enter to exit...");
            Console.ReadLine();
            listener.Stop();
        }
    }
