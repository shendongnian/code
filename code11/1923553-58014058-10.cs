<!-- -->
    public class TextParser
    {
        private static readonly Regex LineRegex = new Regex("\r\n|\r|\n", RegexOptions.Compiled);
        private string text;
        public TextParser(string text)
        {
            this.text = text;
        }
        /// <summary>
        /// Returns whether the specified character index is the end of a line.
        /// </summary>
        /// <param name="index">The index to check.</param>
        /// <returns></returns>
        private bool IsEndOfLine(int index)
        {
            char c = text[index];
            return c == '\r' || (c == '\n' && (index == 0 || text[index - 1] != '\r'));
        }
        /// <summary>
        /// Returns whether the specified character index is the end of a line.
        /// </summary>
        /// <param name="index">The index to check.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool IsEndOfLineAggressiveInlining(int index)
        {
            char c = text[index];
            return c == '\r' || (c == '\n' && (index == 0 || text[index - 1] != '\r'));
        }
        /// <summary>
        /// Returns whether the specified character index is the end of a line.
        /// </summary>
        /// <param name="index">The index to check.</param>
        /// <returns></returns>
        private bool IsEndOfLineUnsafe(int index)
        {
            unsafe
            {
                fixed(char* ptr = text) {
                    char c = ptr[index];
                    return c == '\r' || (c == '\n' && (index == 0 || ptr[index - 1] != '\r'));
                }
            }
        }
        /// <summary>
        /// Returns the number of the line at the specified character index.
        /// </summary>
        /// <param name="index">The index of the character which's line number to get.</param>
        /// <returns></returns>
        public int GetLineNumber(int index)
        {
            if(index < 0 || index > text.Length) { throw new ArgumentOutOfRangeException("index"); }
            int lineNumber = 1;
            int end = index;
            index = 0;
            while(index < end) {
                if(IsEndOfLine(index)) lineNumber++;
                index++;
            }
            return lineNumber;
        }
        /// <summary>
        /// Returns the number of the line at the specified character index.
        /// </summary>
        /// <param name="index">The index of the character which's line number to get.</param>
        /// <returns></returns>
        public int GetLineNumber2(int index)
        {
            if(index < 0 || index > text.Length) { throw new ArgumentOutOfRangeException("index"); }
            int lineNumber = 1;
            int end = index;
            index = 0;
            while(index < end) {
                if(IsEndOfLineAggressiveInlining(index)) lineNumber++;
                index++;
            }
            return lineNumber;
        }
        /// <summary>
        /// Returns the number of the line at the specified character index.
        /// </summary>
        /// <param name="index">The index of the character which's line number to get.</param>
        /// <returns></returns>
        public int GetLineNumberInline(int index)
        {
            if(index < 0 || index > text.Length) { throw new ArgumentOutOfRangeException("index"); }
            int lineNumber = 1;
            int end = index;
            index = 0;
            while(index < end) {
                char c = text[index];
                if(c == '\r' || (c == '\n' && (index == 0 || text[index - 1] != '\r'))) lineNumber++;
                index++;
            }
            return lineNumber;
        }
        /// <summary>
        /// Returns the number of the line at the specified character index.
        /// </summary>
        /// <param name="index">The index of the character which's line number to get.</param>
        /// <returns></returns>
        public int GetLineNumberInline2(int index)
        {
            if(index < 0 || index > text.Length) { throw new ArgumentOutOfRangeException("index"); }
            int lineNumber = 1;
            int end = index;
            index = 0;
            while(index < end) {
                char c = text[index];
                if(c == '\r' | (c == '\n' & (index == 0 || text[index - 1] != '\r'))) lineNumber++;
                index++;
            }
            return lineNumber;
        }
        /// <summary>
        /// Returns the number of the line at the specified character index.
        /// </summary>
        /// <param name="index">The index of the character which's line number to get.</param>
        /// <returns></returns>
        public int GetLineNumberUnsafe(int index)
        {
            if(index < 0 || index > text.Length) { throw new ArgumentOutOfRangeException("index"); }
            int lineNumber = 1;
            int end = index;
            index = 0;
            while(index < end) {
                if(IsEndOfLineUnsafe(index)) lineNumber++;
                index++;
            }
            return lineNumber;
        }
        /// <summary>
        /// Returns the number of the line at the specified character index.
        /// </summary>
        /// <param name="index">The index of the character which's line number to get.</param>
        /// <returns></returns>
        public int GetLineNumberUnsafeInline(int index)
        {
            if(index < 0 || index > text.Length) { throw new ArgumentOutOfRangeException("index"); }
            int lineNumber = 1;
            int end = index;
            unsafe
            {
                fixed(char* ptr = text) {
                    index = 0;
                    while(index < end) {
                        char c = ptr[index];
                        if(c == '\r' || (c == '\n' && (index == 0 || ptr[index - 1] != '\r'))) lineNumber++;
                        index++;
                    }
                }
            }
            return lineNumber;
        }
        /// <summary>
        /// Returns the number of the line at the specified character index. Utilizes a Regex.
        /// </summary>
        /// <param name="index">The index of the character which's line number to get.</param>
        /// <returns></returns>
        public int GetLineNumberRegex(int index)
        {
            return LineRegex.Matches(text.Substring(0, index)).Count + 1;
        }
        /// <summary>
        /// Returns the number of the line at the specified character index. Utilizes a Regex.
        /// </summary>
        /// <param name="index">The index of the character which's line number to get.</param>
        /// <returns></returns>
        public int GetLineNumberRegex2(int index)
        {
            int lineNumber = 1;
            MatchCollection mc = LineRegex.Matches(text);
            for(int y = 0; y < mc.Count; y++) {
                if(mc[y].Index >= index) break;
                lineNumber++;
            }
            return lineNumber;
        }
    }
