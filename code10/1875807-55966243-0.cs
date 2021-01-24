    public class WebSocketRequestHandler
    {
        private const int MaxMessageLength = 0x7FFFFFFF;
        private const byte LengthBitMask = 0x7F;
        private const byte MaskBitMask = 0x80;
        private delegate Task WriteStreamAsyncDelegate(byte[] buffer, int offset, int count, CancellationToken cancellationToken);
        private delegate Task<byte[]> BufferStreamAsyncDelegate(int count, CancellationToken cancellationToken);
        public async Task HandleWebSocketMessagesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var clientListener = ListenForClientMessages(cancellationToken);
            var serverListener = ListenForServerMessages(cancellationToken);
            await Task.WhenAll(clientListener, serverListener);
        }
        private async Task ListenForClientMessages(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await ListenForMessages(YOUR_CLIENT_STREAM_BUFFER_METHOD_DELEGATE, YOUR_SERVER_STREAM_WRITE_METHOD_DELEGATE, cancellationToken);
            }
        }
        private async Task ListenForServerMessages(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await ListenForMessages(YOUR_SERVER_STREAM_BUFFER_METHOD_DELEGATE, YOUR_CLIENT_STREAM_WRITE_METHOD_DELEGATE, cancellationToken);
            }
        }
        private static async Task ListenForMessages(BufferStreamAsyncDelegate sourceStreamReader,
            WriteStreamAsyncDelegate destinationStreamWriter,
            CancellationToken cancellationToken)
        {
            var messageBuilder = new List<byte>();
            var firstByte = await sourceStreamReader(1, cancellationToken);
            messageBuilder.AddRange(firstByte);
            var lengthBytes = await GetLengthBytes(sourceStreamReader, cancellationToken);
            messageBuilder.AddRange(lengthBytes);
            var isMaskBitSet = (lengthBytes[0] & MaskBitMask) != 0;
            var length = GetMessageLength(lengthBytes);
            if (isMaskBitSet)
            {
                var maskBytes = await sourceStreamReader(4, cancellationToken);
                messageBuilder.AddRange(maskBytes);
            }
            var messagePayloadBytes = await sourceStreamReader(length, cancellationToken);
            messageBuilder.AddRange(messagePayloadBytes);
            await destinationStreamWriter(messageBuilder.ToArray(), 0, messageBuilder.Count, cancellationToken);
        }
        private static async Task<byte[]> GetLengthBytes(BufferStreamAsyncDelegate sourceStreamReader, CancellationToken cancellationToken)
        {
            var lengthBytes = new List<byte>();
            var firstLengthByte = await sourceStreamReader(1, cancellationToken);
            lengthBytes.AddRange(firstLengthByte);
            var lengthByteValue = firstLengthByte[0] & LengthBitMask;
            if (lengthByteValue <= 125)
            {
                return lengthBytes.ToArray();
            }
            switch (lengthByteValue)
            {
                case 126:
                {
                    var secondLengthBytes = await sourceStreamReader(2, cancellationToken);
                    lengthBytes.AddRange(secondLengthBytes);
                    return lengthBytes.ToArray();
                }
                case 127:
                {
                    var secondLengthBytes = await sourceStreamReader(8, cancellationToken);
                    lengthBytes.AddRange(secondLengthBytes);
                    return lengthBytes.ToArray();
                }
                default:
                    throw new Exception($"Unexpected first length byte value: {lengthByteValue}");
            }
        }
        private static int GetMessageLength(byte[] lengthBytes)
        {
            byte[] subArray;
            switch (lengthBytes.Length)
            {
                case 1:
                    return lengthBytes[0] & LengthBitMask;
                case 3:
                    if (!BitConverter.IsLittleEndian)
                    {
                        return BitConverter.ToUInt16(lengthBytes, 1);
                    }
                    subArray = lengthBytes.SubArray(1, 2);
                    Array.Reverse(subArray);
                    return BitConverter.ToUInt16(subArray, 0);
                case 9:
                    subArray = lengthBytes.SubArray(1, 8);
                    Array.Reverse(subArray);
                    var retVal = BitConverter.ToUInt64(subArray, 0);
                    if (retVal > MaxMessageLength)
                    {
                        throw new Exception($"Unexpected payload length: {retVal}");
                    }
                    return (int) retVal;
                default:
                    throw new Exception($"Impossibru!!1 The length of lengthBytes array was: '{lengthBytes.Length}'");
            }
        }
    }
