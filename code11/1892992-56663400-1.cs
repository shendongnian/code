    WebSocket ws = await context.WebSockets.AcceptWebSocketAsync();
    // Don't do that, it allocates. Beats the main idea of using [ReadOnly]Span/Memory
    // byte[] bytes = new byte[1024 * 4];
    // We don't need this either, its old API. Websockets support Memory<byte> in an overload
    // ArraySegment<byte> buffer = new ArraySegment<byte>(bytes);
    // We ask for a buffer from the pool with a size hint of 4kb. This way we avoid small allocations and releases
    // P.S. "using" is new syntax for using(disposable) { } which will
    // dispose at the end of the method. new in C# 8.0
    using IMemoryOwner<byte> memory = MemoryPool<byte>.Shared.Rent(1024 * 4);
    while (ws.State == WebSocketState.Open)
    {
        try
        {
            ValueWebSocketReceiveResult request = await ws.ReceiveAsync(memory.Memory, CancellationToken.None);
            switch (request.MessageType)
            {
                case WebSocketMessageType.Text:
                    // we directly work on the rented buffer
                    string msg = Encoding.UTF8.GetString(memory.Memory.Span);
                    // here we slice the memory. Keep in mind that this **DO NOT ALLOCATE** new memory, it just slice the existing memory
                    // reason why it doesnt allocate is, is that Memory<T> is a struct, so its stored on the stack and contains start 
                    // and end position of the sliced array
                    JsonDocument jsonDocument = JsonDocument.Parse(memory.Memory.Slice(0, request.Count));
                    break;
                default:
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}\r\n{e.StackTrace}");
        }
    }
