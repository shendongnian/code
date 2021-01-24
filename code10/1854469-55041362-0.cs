    public string test(string input)
    {
        string result = Subset.FirstOrDefault(a => a == input);
        if (result == null)
            return test(input.Substring(0, input.Length - 2));
        else
            return result;
    }
    
