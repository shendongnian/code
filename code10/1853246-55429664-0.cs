    public ref struct Utf8JsonStreamReader
    {
        private readonly Stream _stream;
        private IMemoryOwner<byte> _buffer;
        private Utf8JsonReader _jsonReader;
        private int _dataSize;
        public Utf8JsonStreamReader(Stream stream)
        {
            _stream = stream;
            _buffer = MemoryPool<byte>.Shared.Rent(32 * 1024);
            _jsonReader = default;
            _dataSize = -1;
        }
        public void Dispose()
        {
            _buffer.Dispose();
        }
        public bool Read()
        {
            // read could be unsuccessful due to insufficient buffer size, retrying in loop with increasing buffer sizes
            while (!_jsonReader.Read())
            {
                if (_dataSize == 0)
                    return false;
                MoveNext();
            }
            return true;
        }
        private void MoveNext()
        {
            int leftOver = 0;
            if (_dataSize != -1)
            {
                leftOver = _dataSize - (int)_jsonReader.CurrentState.BytesConsumed;
                if (leftOver == _buffer.Memory.Length)
                {
                    // current JSON token is to large to fit in buffer, try growing buffer
                    var newBuffer = MemoryPool<byte>.Shared.Rent(2 * _buffer.Memory.Length);
                    _buffer.Memory.CopyTo(newBuffer.Memory);
                    _buffer.Dispose();
                    _buffer = newBuffer;
                }
                if (leftOver != 0)
                {
                    // we haven't read to the end of previous buffer, carry forward
                    _buffer.Memory.Slice(_dataSize - leftOver, leftOver).CopyTo(_buffer.Memory);
                }
            }
            _dataSize = leftOver + _stream.Read(_buffer.Memory[leftOver..].Span);
            _jsonReader = new Utf8JsonReader(_buffer.Memory[0.._dataSize].Span, _dataSize == 0, _jsonReader.CurrentState);
        }
        public JsonTokenType TokenType => _jsonReader.TokenType;
        public SequencePosition Position => _jsonReader.Position;
        public bool HasValueSequence => _jsonReader.HasValueSequence;
        public int CurrentDepth => _jsonReader.CurrentDepth;
        public long BytesConsumed => _jsonReader.BytesConsumed;
        public ReadOnlySequence<byte> ValueSequence => _jsonReader.ValueSequence;
        public ReadOnlySpan<byte> ValueSpan => _jsonReader.ValueSpan;
        public bool GetBoolean() => _jsonReader.GetBoolean();
        public decimal GetDecimal() => _jsonReader.GetDecimal();
        public double GetDouble() => _jsonReader.GetDouble();
        public int GetInt32() => _jsonReader.GetInt32();
        public long GetInt64() => _jsonReader.GetInt64();
        public float GetSingle() => _jsonReader.GetSingle();
        public string GetString() => _jsonReader.GetString();
        public uint GetUInt32() => _jsonReader.GetUInt32();
        public ulong GetUInt64() => _jsonReader.GetUInt64();
        public bool TryGetDecimal(out decimal value) => _jsonReader.TryGetDecimal(out value);
        public bool TryGetDouble(out double value) => _jsonReader.TryGetDouble(out value);
        public bool TryGetInt32(out int value) => _jsonReader.TryGetInt32(out value);
        public bool TryGetInt64(out long value) => _jsonReader.TryGetInt64(out value);
        public bool TryGetSingle(out float value) => _jsonReader.TryGetSingle(out value);
        public bool TryGetUInt32(out uint value) => _jsonReader.TryGetUInt32(out value);
        public bool TryGetUInt64(out ulong value) => _jsonReader.TryGetUInt64(out value);
    }
