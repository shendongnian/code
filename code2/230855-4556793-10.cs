    enum WordPolicy
    {
        None,
        ThrowIfTooLong,
        CutIfTooLong
    }
    public static IEnumerable<string> SplitOnLength(this string input, int length, WordPolicy wordPolicy)
    {
        int index = 0;
        while (index < input.Length)
        {
            int stepsBackward = 0;
            if (index + length < input.Length)
            {
                if (wordPolicy != WordPolicy.None)
                {
                    yield return GetBiggestAllowableSubstring(input, index, length, wordPolicy, out stepsBackward);
                }
                else
                {
                    yield return input.Substring(index, length);
                }
            }
            else
            {
                yield return input.Substring(index);
            }
            index += (length - stepsBackward);
        }
    }
    static string GetBiggestAllowableSubstring(string input, int index, int length, WordPolicy wordPolicy, out int stepsBackward)
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
            if (wordPolicy == WordPolicy.ThrowIfTooLong)
            {
                throw new ArgumentOutOfRangeException("The input string contains at least one word greater in length than the specified length.");
            }
            else
            {
                stepsBackward = 0;
                lastIndex = index + length - 1;
            }
        }
        return input.Substring(index, lastIndex - index + 1);
    }
