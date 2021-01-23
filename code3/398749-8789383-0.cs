    static string GetWord(String input, int charIndex) {
        if (charIndex > (input.Length - 1)) { throw new IndexOutOfRangeException(); }
        if (!Regex.IsMatch(input[charIndex].ToString(), @"\w")) {
            throw new ArgumentException(
                String.Format("The character at position {0} is not in a word", charIndex));
        }
        return (
            from Match mx in Regex.Matches(input, @"\w+")
            where (mx.Index <= charIndex) && ((mx.Index + mx.Length - 1) >= charIndex)
            select mx).Single().Value;
    }
