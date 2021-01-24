private static async Task TestNetworking()
        {
            EndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 12345);
            await Task.Factory.StartNew(async () =>
            {
                try
                {
                    SocketServer server = new UdpServer();
                    bool bound = server.Bind(serverEndPoint);
                    if (bound)
                    {
                        Console.WriteLine($"[Server] Bound server socket!");
                        Console.WriteLine($"[Server] Starting server at {serverEndPoint}!");
                        await server.StartAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }, CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            await Task.Factory.StartNew(async () =>
            {
                SocketClient client = new UdpClient();
                bool bound = client.Bind(new IPEndPoint(IPAddress.Any, 7007));
                if (bound)
                {
                    Console.WriteLine($"[Client] Bound client socket!");
                }
                if (bound && client.Connect(serverEndPoint))
                {
                    Console.WriteLine($"[Client] Connected to {serverEndPoint}!");
                    byte[] message = Encoding.UTF8.GetBytes("Hello World!");
                    Memory<byte> messageBuffer = new Memory<byte>(message);
                    byte[] response = new byte[ReceiveResult.PacketSize];
                    Memory<byte> responseBuffer = new Memory<byte>(response);
                    Stopwatch stopwatch = new Stopwatch();
                    const int packetsToSend = 1_000_000, statusPacketThreshold = 10_000;
                    Console.WriteLine($"Started sending packets (total packet count: {packetsToSend})");
                    for (int i = 0; i < packetsToSend; i++)
                    {
                        if (i % statusPacketThreshold == 0)
                        {
                            Console.WriteLine($"Sent {i} packets out of {packetsToSend} ({((double)i / packetsToSend) * 100:F2}%)");
                        }
                        try
                        {
                            //Console.WriteLine($"[Client > {serverEndPoint}] Sending packet {i}");
                            stopwatch.Start();
                            int sentBytes = await client.SendAsync(serverEndPoint, messageBuffer, SocketFlags.None);
                            //Console.WriteLine($"[Client] Sent {sentBytes} to {serverEndPoint}");
                            ReceiveResult result = await client.ReceiveAsync(serverEndPoint, SocketFlags.None, responseBuffer);
                            //Console.WriteLine($"[{result.RemoteEndPoint} > Client] : {Encoding.UTF8.GetString(result.Contents)}");
                            serverEndPoint = result.RemoteEndPoint;
                            stopwatch.Stop();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            i--;
                            await Task.Delay(1);
                        }
                    }
                    double approxBandwidth = (packetsToSend * ReceiveResult.PacketSize) / (1_000_000.0 * (stopwatch.ElapsedMilliseconds / 1000.0));
                    Console.WriteLine($"Sent {packetsToSend} packets of {ReceiveResult.PacketSize} bytes in {stopwatch.ElapsedMilliseconds:N} milliseconds.");
                    Console.WriteLine($"Approximate bandwidth: {approxBandwidth} MBps");
                }
            }, CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default).Result;
        }
Shared Code:
internal readonly struct AsyncReadToken
    {
        public readonly CancellationToken CancellationToken;
        public readonly TaskCompletionSource<ReceiveResult> CompletionSource;
        public readonly byte[] RentedBuffer;
        public readonly Memory<byte> UserBuffer;
        public AsyncReadToken(byte[] rentedBuffer, Memory<byte> userBuffer, TaskCompletionSource<ReceiveResult> tcs,
            CancellationToken cancellationToken = default)
        {
            RentedBuffer = rentedBuffer;
            UserBuffer = userBuffer;
            CompletionSource = tcs;
            CancellationToken = cancellationToken;
        }
    }
internal readonly struct AsyncWriteToken
    {
        public readonly CancellationToken CancellationToken;
        public readonly TaskCompletionSource<int> CompletionSource;
        public readonly byte[] RentedBuffer;
        public readonly Memory<byte> UserBuffer;
        public AsyncWriteToken(byte[] rentedBuffer, Memory<byte> userBuffer, TaskCompletionSource<int> tcs,
            CancellationToken cancellationToken = default)
        {
            RentedBuffer = rentedBuffer;
            UserBuffer = userBuffer;
            CompletionSource = tcs;
            CancellationToken = cancellationToken;
        }
    }
public readonly struct ReceiveResult
    {
        public const int PacketSize = 1024;
        public readonly SocketAsyncEventArgs ClientArgs;
        public readonly Memory<byte> Contents;
        public readonly int Count;
        public readonly EndPoint RemoteEndPoint;
        public ReceiveResult(SocketAsyncEventArgs clientArgs, Memory<byte> contents, int count, EndPoint remoteEndPoint)
        {
            ClientArgs = clientArgs;
            Contents = contents;
            Count = count;
            RemoteEndPoint = remoteEndPoint;
        }
    }
Server Code:
public abstract class SocketServer
    {
        protected readonly Socket socket;
        protected SocketServer(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
        {
            socket = new Socket(addressFamily, socketType, protocolType);
        }
        public bool Bind(in EndPoint localEndPoint)
        {
            try
            {
                socket.Bind(localEndPoint);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public abstract Task StartAsync();
    }
public class UdpServer : SocketServer
    {
        private const int MaxPooledObjects = 1;
        private readonly ConcurrentDictionary<EndPoint, ConcurrentQueue<byte[]>> clients;
        private readonly ArrayPool<byte> receiveBufferPool =
            ArrayPool<byte>.Create(ReceiveResult.PacketSize, MaxPooledObjects);
        private readonly ArrayPool<byte> sendBufferPool =
            ArrayPool<byte>.Create(ReceiveResult.PacketSize, MaxPooledObjects);
        private readonly ObjectPool<SocketAsyncEventArgs> socketAsyncEventArgsPool =
            new DefaultObjectPool<SocketAsyncEventArgs>(new DefaultPooledObjectPolicy<SocketAsyncEventArgs>(),
                MaxPooledObjects);
        private void HandleIOCompleted(object? sender, SocketAsyncEventArgs eventArgs)
        {
            bool closed = false;
            switch (eventArgs.LastOperation)
            {
                case SocketAsyncOperation.SendTo:
                    AsyncWriteToken asyncWriteToken = (AsyncWriteToken)eventArgs.UserToken;
                    if (asyncWriteToken.CancellationToken.IsCancellationRequested)
                    {
                        asyncWriteToken.CompletionSource.TrySetCanceled();
                    }
                    else
                    {
                        if (eventArgs.SocketError != SocketError.Success)
                        {
                            asyncWriteToken.CompletionSource.TrySetException(
                                new SocketException((int)eventArgs.SocketError));
                        }
                        else
                        {
                            asyncWriteToken.CompletionSource.TrySetResult(eventArgs.BytesTransferred);
                        }
                    }
                    sendBufferPool.Return(asyncWriteToken.RentedBuffer, true);
                    socketAsyncEventArgsPool.Return(eventArgs);
                    break;
                case SocketAsyncOperation.ReceiveFrom:
                    AsyncReadToken asyncReadToken = (AsyncReadToken)eventArgs.UserToken;
                    if (asyncReadToken.CancellationToken.IsCancellationRequested)
                    {
                        asyncReadToken.CompletionSource.SetCanceled();
                    }
                    else
                    {
                        if (eventArgs.SocketError != SocketError.Success)
                        {
                            asyncReadToken.CompletionSource.SetException(
                                new SocketException((int)eventArgs.SocketError));
                        }
                        else
                        {
                            eventArgs.MemoryBuffer.CopyTo(asyncReadToken.UserBuffer);
                            ReceiveResult result = new ReceiveResult(eventArgs, asyncReadToken.UserBuffer,
                                eventArgs.BytesTransferred, eventArgs.RemoteEndPoint);
                            asyncReadToken.CompletionSource.SetResult(result);
                        }
                    }
                    receiveBufferPool.Return(asyncReadToken.RentedBuffer, true);
                    break;
                case SocketAsyncOperation.Disconnect:
                    closed = true;
                    break;
                case SocketAsyncOperation.Accept:
                case SocketAsyncOperation.Connect:
                case SocketAsyncOperation.None:
                case SocketAsyncOperation.Receive:
                case SocketAsyncOperation.ReceiveMessageFrom:
                case SocketAsyncOperation.Send:
                case SocketAsyncOperation.SendPackets:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
            if (closed)
            {
                // handle the client closing the connection on tcp servers at some point
            }
        }
        private Task<ReceiveResult> ReceiveAsync(EndPoint remoteEndPoint, SocketFlags socketFlags,
            Memory<byte> outputBuffer, CancellationToken cancellationToken = default)
        {
            TaskCompletionSource<ReceiveResult> tcs = new TaskCompletionSource<ReceiveResult>();
            byte[] rentedBuffer = receiveBufferPool.Rent(ReceiveResult.PacketSize);
            Memory<byte> memoryBuffer = new Memory<byte>(rentedBuffer);
            SocketAsyncEventArgs args = socketAsyncEventArgsPool.Get();
            args.SetBuffer(memoryBuffer);
            args.SocketFlags = socketFlags;
            args.RemoteEndPoint = remoteEndPoint;
            args.UserToken = new AsyncReadToken(rentedBuffer, outputBuffer, tcs, cancellationToken);
            // if the receive operation doesn't complete synchronously, returns the awaitable task
            if (socket.ReceiveFromAsync(args)) return tcs.Task;
            args.MemoryBuffer.CopyTo(outputBuffer);
            ReceiveResult result = new ReceiveResult(args, outputBuffer, args.BytesTransferred, args.RemoteEndPoint);
            receiveBufferPool.Return(rentedBuffer, true);
            return Task.FromResult(result);
        }
        private Task<int> SendAsync(SocketAsyncEventArgs clientArgs, Memory<byte> inputBuffer, SocketFlags socketFlags,
            CancellationToken cancellationToken = default)
        {
            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
            byte[] rentedBuffer = sendBufferPool.Rent(ReceiveResult.PacketSize);
            Memory<byte> memoryBuffer = new Memory<byte>(rentedBuffer);
            inputBuffer.CopyTo(memoryBuffer);
            SocketAsyncEventArgs args = clientArgs;
            args.SetBuffer(memoryBuffer);
            args.SocketFlags = socketFlags;
            args.UserToken = new AsyncWriteToken(rentedBuffer, inputBuffer, tcs, cancellationToken);
            // if the send operation doesn't complete synchronously, return the awaitable task
            if (socket.SendToAsync(args)) return tcs.Task;
            int result = args.BytesTransferred;
            sendBufferPool.Return(rentedBuffer, true);
            socketAsyncEventArgsPool.Return(args);
            return Task.FromResult(result);
        }
        public UdpServer() : base(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        {
            clients = new ConcurrentDictionary<EndPoint, ConcurrentQueue<byte[]>>();
            for (int i = 0; i < MaxPooledObjects; i++)
            {
                SocketAsyncEventArgs args = new SocketAsyncEventArgs();
                args.Completed += HandleIOCompleted;
                socketAsyncEventArgsPool.Return(args);
            }
        }
        /// <inheritdoc />
        public override async Task StartAsync()
        {
            EndPoint nullEndPoint = new IPEndPoint(IPAddress.Any, 0);
            byte[] receiveBuffer = new byte[ReceiveResult.PacketSize];
            Memory<byte> receiveBufferMemory = new Memory<byte>(receiveBuffer);
            while (true)
            {
                ReceiveResult result = await ReceiveAsync(nullEndPoint, SocketFlags.None, receiveBufferMemory);
                //Console.WriteLine($"[{result.RemoteEndPoint} > Server] : {Encoding.UTF8.GetString(result.Contents.Span)}");
                int sentBytes = await SendAsync(result.ClientArgs, result.Contents, SocketFlags.None);
                //Console.WriteLine($"[Server > {result.RemoteEndPoint}] Sent {sentBytes} bytes to {result.RemoteEndPoint}");
            }
        }
Client Code:
public abstract class SocketClient
    {
        protected readonly Socket socket;
        protected SocketClient(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
        {
            socket = new Socket(addressFamily, socketType, protocolType);
        }
        public bool Bind(in EndPoint localEndPoint)
        {
            try
            {
                socket.Bind(localEndPoint);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public bool Connect(in EndPoint remoteEndPoint)
        {
            try
            {
                socket.Connect(remoteEndPoint);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public abstract Task<ReceiveResult> ReceiveAsync(EndPoint remoteEndPoint, SocketFlags socketFlags,
            Memory<byte> outputBuffer);
        public abstract Task<int> SendAsync(EndPoint remoteEndPoint, Memory<byte> inputBuffer, SocketFlags socketFlags);
    }
public class UdpClient : SocketClient
    {
        /// <inheritdoc />
        public UdpClient() : base(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        {
        }
        public override async Task<ReceiveResult> ReceiveAsync(EndPoint remoteEndPoint, SocketFlags socketFlags,
            Memory<byte> outputBuffer)
        {
            byte[] buffer = new byte[ReceiveResult.PacketSize];
            SocketReceiveFromResult result =
                await socket.ReceiveFromAsync(new ArraySegment<byte>(buffer), socketFlags, remoteEndPoint);
            buffer.CopyTo(outputBuffer);
            return new ReceiveResult(default, outputBuffer, result.ReceivedBytes, result.RemoteEndPoint);
            /*
            SocketAsyncEventArgs args = new SocketAsyncEventArgs();
            args.SetBuffer(new byte[ReceiveResult.PacketSize]);
            args.SocketFlags = socketFlags;
            args.RemoteEndPoint = remoteEndPoint;
            SocketTask awaitable = new SocketTask(args);
            while (ReceiveResult.PacketSize > args.BytesTransferred)
            {
                await socket.ReceiveFromAsync(awaitable);
            }
            return new ReceiveResult(args.MemoryBuffer, args.RemoteEndPoint);
            */
        }
        public override async Task<int> SendAsync(EndPoint remoteEndPoint, Memory<byte> buffer, SocketFlags socketFlags)
        {
            return await socket.SendToAsync(buffer.ToArray(), socketFlags, remoteEndPoint);
            /*
            SocketAsyncEventArgs args = new SocketAsyncEventArgs();
            args.SetBuffer(buffer);
            args.SocketFlags = socketFlags;
            args.RemoteEndPoint = remoteEndPoint;
            SocketTask awaitable = new SocketTask(args);
            while (buffer.Length > args.BytesTransferred)
            {
                await socket.SendToAsync(awaitable);
            }
            return args.BytesTransferred;
            */
        }
    }
