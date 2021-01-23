    static string ReplaceNonCharacters(string aString, char replacement)
    {
        var sb = new StringBuilder(aString.Length);
        for (var i = 0; i < aString.Length; i++)
        {
            if (char.IsSurrogatePair(aString, i))
            {
                int c = char.ConvertToUtf32(aString, i);
                i++;
                if (IsCharacter(c))
                    sb.Append(char.ConvertFromUtf32(c));
                else
                    sb.Append(replacement);
            }
            else
            {
                char c = aString[i];
                if (IsCharacter(c))
                    sb.Append(c);
                else
                    sb.Append(replacement);
            }
        }
        return sb.ToString();
    }
    static bool IsCharacter(int point)
    {
        return point < 0xFDD0 || // everything below here is fine
            point > 0xFDEF &&    // exclude the 0xFFD0...0xFDEF non-characters
            (point & 0xfffE) != 0xFFFE; // exclude all other non-characters
    }
