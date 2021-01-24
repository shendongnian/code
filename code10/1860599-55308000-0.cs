    public static bool BeginsWithAVowel(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return false;
        var vowels = "AaEeIiOoUu";
        return vowels.Contains(input.Substring(0, 1));
    }
