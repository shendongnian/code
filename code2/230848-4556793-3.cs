    public static IEnumerable<string> SplitOnLength(this string input, int length, bool maintainWords)
    {
        int index = 0;
        while (index < input.Length)
        {
            int stepsBackward = 0;
            if (index + length < input.Length)
            {
                if (maintainWords)
                {
                    yield return GetBiggestAllowableSubstring(input, index, length, out stepsBackward);
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
