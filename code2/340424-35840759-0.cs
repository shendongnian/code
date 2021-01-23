    public class LineBreakCounter
    {
        List<int> lineBreaks_ = new List<int>();
        int length_;
        public LineBreakCounter(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));
            length_ = text.Length;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\n')
                    lineBreaks_.Add(i);
                else if (text[i] == '\r' && i < text.Length + 1 && text[i + 1] == '\n')
                    lineBreaks_.Add(++i);
            }
        }
        public int GetLine(int offset)
        {
            if (offset < 0 || offset > length_)
                throw new ArgumentOutOfRangeException(nameof(offset));
            var result = lineBreaks_.BinarySearch(offset);
            if (result < 0)
                return ~result;
            else
                return result;
        }
    }
