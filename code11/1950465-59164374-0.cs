    public static class StreamReaderExtensions
    {
        public static bool TryReadNextLine(this StreamReader reader, out string line)
        {
            var isAvailable = reader != null &&
                              !reader.EndOfStream;
            line = isAvailable ? reader.ReadLine() : null;
            return isAvailable;
        }
        public static bool TryReadPrevLine(this StreamReader reader, out string line)
        {
            var stream = reader.BaseStream;
            var encoding = reader.CurrentEncoding;
            var bom = GetBOM(encoding);
            var isAvailable = reader != null &&
                              stream.Position > 0;
            if(!isAvailable)
            {
                line = null;
                return false;
            }
            
            var buffer = new List<byte>();
            var str = string.Empty;
            stream.Position++;
            while (!str.StartsWith(Environment.NewLine))
            {
                stream.Position -= 2;
                buffer.Insert(0, (byte)stream.ReadByte());
                var reachedBOM = buffer.Take(bom.Length).SequenceEqual(bom);
                if (reachedBOM)
                    buffer = buffer.Skip(bom.Length).ToList();
                str = encoding.GetString(buffer.ToArray());
                if (reachedBOM)
                    break;
            }
            stream.Position--;
            line = str.Trim(Environment.NewLine.ToArray());
            return true;
        }
        private static byte[] GetBOM(Encoding encoding)
        {
            if (encoding.Equals(Encoding.UTF7))
                return new byte[] { 0x2b, 0x2f, 0x76 };
            if (encoding.Equals(Encoding.UTF8))
                return new byte[] { 0xef, 0xbb, 0xbf };
            if (encoding.Equals(Encoding.Unicode))
                return new byte[] { 0xff, 0xfe };
            if (encoding.Equals(Encoding.BigEndianUnicode))
                return new byte[] { 0xfe, 0xff };
            if (encoding.Equals(Encoding.UTF32))
                return new byte[] { 0, 0, 0xfe, 0xff };
            return new byte[0];
        }
    }
