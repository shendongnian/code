    private string Solve(string sentence)
    {
        if (sentence != null && sentence.Length > 0)
        {
            return sentence[0].ToString().ToUpper() + sentence.Substring(1).ToLower();
        }
        else
        {
            return sentence;
        }
    }
