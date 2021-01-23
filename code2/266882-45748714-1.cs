    public static class StreamReaderExtension
    {
        /// <summary>
        /// Searches from the beginning of the stream for the indicated
        /// <paramref name="pattern"/>. Once found, returns the position within the stream
        /// that the pattern begins at.
        /// </summary>
        /// <param name="pattern">The <c>string</c> pattern to search for in the stream.</param>
        /// <returns>If <paramref name="pattern"/> is found in the stream, then the start position
        /// within the stream of the pattern; otherwise, -1.</returns>
        /// <remarks>Please note: this method will change the current stream position of this instance of
        /// <see cref="System.IO.StreamReader"/>. When it completes, the position of the reader will
        /// be set to 0.</remarks>
        public static long FindSeekPosition(this StreamReader reader, string pattern)
        {
            if (!string.IsNullOrEmpty(pattern) && reader.BaseStream.CanSeek)
            {
                reader.BaseStream.Position = 0;
                reader.DiscardBufferedData();
                StringBuilder buff = new StringBuilder();
                long start = 0;
                long charCount = 0;
                List<char> matches = new List<char>(pattern.ToCharArray());
                bool startFound = false;
                while (!reader.EndOfStream)
                {
                    char chr = (char)reader.Read();
                    if (chr == matches[0] && !startFound)
                    {
                        startFound = true;
                        start = charCount;
                    }
                    if (startFound && matches.Contains(chr))
                    {
                        buff.Append(chr);
                        if (buff.Length == pattern.Length
                            && buff.ToString() == pattern)
                        {
                            reader.BaseStream.Position = 0;
                            reader.DiscardBufferedData();
                            return start;
                        }
                        bool reset = false;
                        if (buff.Length > pattern.Length)
                        {
                            reset = true;
                        }
                        else
                        {
                            string subStr = pattern.Substring(0, buff.Length);
                            if (buff.ToString() != subStr)
                            {
                                reset = true;
                            }
                        }
                        if (reset)
                        {
                            buff.Length = 0;
                            startFound = false;
                            start = 0;
                        }
                    }
                    charCount++;
                }
                reader.BaseStream.Position = 0;
                reader.DiscardBufferedData();
            }
            return -1;
        }
    }
}
