    public static IEnumerable<string> Split(string str)
    {
        char [] chars = str.ToCharArray();
        int last = 0;
        for(int i = 1; i < chars.Length; i++) {
            if(char.IsLetter(chars[i])) {
                yield return new string(chars, last, i - last);
                last = i;
            }
        }
        yield return new string(chars, last, chars.Length - last);
    }
