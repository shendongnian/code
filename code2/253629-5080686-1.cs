    bool IsPalindrome(string input)
    {
        return
            Enumerable.Range(0, input.Length/2)
                        .Select(i => input[i] == input[input.Length - i - 1])
                        .All(b => b);
    }
