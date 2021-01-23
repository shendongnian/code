    static string GetBiggestAllowableSubstring(string input, int index, int length, out int stepsBackward)
    {
        stepsBackward = 0;
        int lastIndex = index + length - 1;
        if (!char.IsWhiteSpace(input[lastIndex + 1]))
        {
            int adjustedLastIndex = input.LastIndexOf(' ', lastIndex, length);
            stepsBackward = lastIndex - adjustedLastIndex;
            lastIndex = adjustedLastIndex;
        }
        if (lastIndex == -1)
        {
            throw new ArgumentOutOfRangeException("The input string contains at least one word greater in length than the specified length.");
        }
        return input.Substring(index, lastIndex - index + 1);
    }
