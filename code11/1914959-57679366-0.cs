    internal class BinaryKeyStorage
    {
        private const string FILE_PATH = @"data.bin";
        private static MemoryMappedFile _memoryFile;
        private static MemoryMappedViewStream _memoryFileStream;
        private static Dictionary<string, Entry> _index;
        private class Entry
        {
            public Entry(int position, int length)
            {
                Position = position;
                Length = length;
            }
            public int Position { get; }
            public int Length { get; }
        }
        public static void CreateFile(Dictionary<string, byte[]> keyValues)
        {
            // 4 bytes for int count of entries
            // and per entry:
            // - string length + 1 byte for string prefix
            // - 2x4 bytes for int address start and length
            var headerLength = 4 + keyValues.Keys.Sum(dataKey => dataKey.Length + 9);
            var nextStartPosition = headerLength;
            using (var binaryWriter = new BinaryWriter(File.Open(FILE_PATH, FileMode.Create)))
            {
                binaryWriter.Write(keyValues.Count);
                // writing header
                foreach (var keyValue in keyValues)
                {
                    binaryWriter.Write(keyValue.Key);
                    binaryWriter.Write(nextStartPosition);
                    binaryWriter.Write(keyValue.Value.Length);
                    nextStartPosition += keyValue.Value.Length;
                }
                // writing data
                foreach (var keyValue in keyValues)
                {
                    binaryWriter.Write(keyValue.Value);
                }
            }
        }
        public static List<string> GetAllKeys()
        {
            InitializeIndexIfNeeded();
            return _index.Keys.ToList();
        }
        public static byte[] GetData(string key)
        {
            InitializeIndexIfNeeded();
            var entry = _index[key];
            _memoryFileStream.Seek(entry.Position, SeekOrigin.Begin);
            var data = new byte[entry.Length];
            _memoryFileStream.Read(data, 0, data.Length);
            return data;
        }
        private static void InitializeIndexIfNeeded()
        {
            if (_memoryFile != null) return;
            _memoryFile = MemoryMappedFile.CreateFromFile(FILE_PATH, FileMode.Open);
            _memoryFileStream = _memoryFile.CreateViewStream();
            _index = new Dictionary<string, Entry>();
            using (var binaryReader = new BinaryReader(_memoryFileStream, Encoding.Default, true))
            {
                var count = binaryReader.ReadInt32();
                for (var i = 0; i < count; i++)
                {
                    var dataKey = binaryReader.ReadString();
                    var dataPosition = binaryReader.ReadInt32();
                    var dataLength = binaryReader.ReadInt32();
                    _index.Add(dataKey, new Entry(dataPosition, dataLength));
                }
            }
        }
    }
