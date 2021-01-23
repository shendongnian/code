    public int GetNumber(string input)
    {
       return int.Parse(input.Substring(0, input.Length - 2));
    }
    public char GetCode(string input)
    {
       return input.Last();
    }
