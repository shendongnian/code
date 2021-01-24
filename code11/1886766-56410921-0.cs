    static bool IsPalindrome(string s)
    {
        return s.Where(Char.IsLetterOrDigit).Take(s.Length / 2)
            .SequenceEqual(s.Reverse().Where(Char.IsLetterOrDigit).Take(s.Length / 2));
    }
