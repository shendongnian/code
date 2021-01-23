    public static string Get2LineDisplayText(string original)
    {
        //Degenerate case with only 1 word
        if (!original.Any(Char.IsWhiteSpace))
        {
            return original;
        }
        int mid = original.Length / 2;
        if (!Char.IsWhiteSpace(original[mid]))
        {
            for (int i = 1; i < mid; i += i)
            {
                if (Char.IsWhiteSpace(original[mid + i]))
                {
                    mid = mid + i;
                    break;
                }
                if (Char.IsWhiteSpace(original[mid - i]))
                {
                    mid = mid - i;
                    break;
                }
            }
        }
        return original.Substring(0, mid)
               + "<br />" + original.Substring(mid + 1);
    }
