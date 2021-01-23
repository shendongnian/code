    public class LineReader : StreamReader
    {
        public LineReader(Stream stream)
            : base(stream)
        {
        }
        public override string ReadLine()
        {
            string line = String.Empty;
            int bufferSize = 256;
            char[] buffer = new char[bufferSize];
            while (true)
            {
                foreach (var i in Enumerable.Range(0, bufferSize))
                {
                    if (this.ReadBlock(buffer, i, 1) != 1
                        || buffer[i] == '\r')
                    {
                        line += new String(buffer, 0, i);
                        return line;
                    }
                }
                line += new String(buffer);
            }
        }
    }
