    static string Truncated(string input)
    {
        var indexOfEighteenthSpace = IndexOfCharSeekFromStart(input, ' ', 18);
        if (indexOfEighteenthSpace <= 0) return input;
        var indexOfSecondLastSpace = IndexOfCharSeekFromEnd(input, ' ', 2);
        if (indexOfSecondLastSpace <= 0) return input;
        if (indexOfSecondLastSpace <= indexOfEighteenthSpace) return input;
        var leadingSegment = input.AsSpan().Slice(0, indexOfEighteenthSpace);
        var trailingSegment = input.AsSpan().Slice(indexOfSecondLastSpace);
        return string.Concat(leadingSegment, " ... ", trailingSegment);
        static int IndexOfCharSeekFromStart(string input, char value, int count)
        {
           var startIndex = 0;
           for (var i = 0; i < count; i++)
           {
               startIndex = input.IndexOf(value, startIndex + 1);
               if (startIndex <= 0) return startIndex;
           }
            return startIndex;
        }
        static int IndexOfCharSeekFromEnd(string input, char value, int count)
        {
           var endIndex = input.Length - 1;
           for (var i = 0; i < count; i++)
           {
               endIndex = input.LastIndexOf(value, endIndex - 1);
               if (endIndex <= 0) return endIndex;
           }
            return endIndex;
        }
    }   
