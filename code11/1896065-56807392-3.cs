    static class FileStreamExtensions
    {
        private static readonly char[] newLine = Environment.NewLine.ToCharArray();
        private static readonly int length = Environment.NewLine.Length;
        private static readonly char eof = '\uFFFF';
        public static string ReadLine(this FileStream fs, out long position)
        {
            position = fs.Position;
            var chars = new List<char>();
            char c;
            while ((c = (char)fs.ReadByte()) != eof && (chars.Count < length || !chars.Skip(chars.Count - 2).SequenceEqual(newLine)))
            {
                chars.Add(c);
            }
            fs.Position--;
            if (chars.Count == 0)
                return null;
            return new string(chars.ToArray());
        }
        public static void WriteLine(this FileStream fs, long position, string line)
        {
            var bytes = line.ToCharArray().Concat(newLine).Select(c => (byte)c).ToArray();
            fs.Position = position;
            fs.Write(bytes, 0, bytes.Length);
        }
    }
