    public static int CountNonLetterDigitCharsAtEnd(string input)
    {
        int i;
        for (i = input.Length - 1; i >= 0 && !char.IsLetterOrDigit(input[i]); --i)
            ;
        return input.Length - i - 1;
    }
