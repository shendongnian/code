    private static string AlphaCode(String Input)
    {
        List<String> capLetter = new List<String>();
        foreach (Char c in Input)
        {
            if (char.IsLetter(c))
            {
                String letter = c.ToString();
                if (letter == letter.ToUpper()) { capLetter.Add(letter); }
            }
        }
        return String.Join(String.Empty, capLetter.ToArray());
    }
