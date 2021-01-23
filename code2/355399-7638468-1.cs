    public int GetNumber(string input)
    {
       return int.Parse(input.Substring(0, input.Length - 1));
    }
    public char GetCode(string input)
    {
       return input.Last();
    }
