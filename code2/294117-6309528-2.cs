    private static string AlphaCode(String Input)
    {
        String capCase = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Input.ToString().ToLower());
        List<String> capLetter = new List<String>();
        foreach (Char c in capCase)
        {
            if (char.IsLetter(c))
            {
                String letter = c.ToString();
                if (letter == letter.ToUpper()) { capLetter.Add(letter); }
            }
        }
        return String.Join(String.Empty, capLetter.ToArray());
    }
