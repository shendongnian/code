    static void IsAnyCharacterRightToLeft(string s)
    {
        for (var i = 0; i < s.Length; i += char.IsSurrogatePair(s, i) ? 2 : 1)
        {
            var codepoint = char.ConvertToUtf32(s, i);
            if (IsRorALCat(codepoint))
            {
                return true;
            }
        }
        return false;
    }
