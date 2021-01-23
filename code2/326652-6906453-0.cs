    private void IsOnlyOneChar(string input, char c)
    {
        for (var i = 0; i < input.Length; ++i)
            if (input[i] != c)
                return false;
        return true;
    }
