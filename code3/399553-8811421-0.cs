    public IEnumerable<string> CreateCombinations(IEnumerable<char> input, int length)
    {
        foreach (var c in input)
        {
            if (length == 1)
                yield return c.ToString();
            else 
            {
                foreach (var s in CreateCombinations(input, length - 1))
                    yield return c.ToString() + s;
            }
        }
    }
