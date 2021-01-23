        static async Task ReadAsync(Socket s)
        {
            // Reusable SocketAsyncEventArgs and awaitable wrapper 
            var args = new SocketAsyncEventArgs();
            args.SetBuffer(new byte[0x1000], 0, 0x1000);
            var awaitable = new SocketAwaitable(args);
            // Do processing, continually receiving from the socket 
            while (true)
            {
                await s.ReceiveAsync(awaitable);
                int bytesRead = args.BytesTransferred;
                if (bytesRead <= 0) break;
                Console.WriteLine(bytesRead);
            }
        }
