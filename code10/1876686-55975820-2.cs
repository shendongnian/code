public static string MakePigLatin(string str) {
    MatchCollection matches = Regex.Matches(str, @"([a-zA-Z]*)([^a-zA-Z]*)");
    StringBuilder result = new StringBuilder(str.Length * 2);
    for (int i = 0; i < matches.Count; ++i) {
        string pigTrans = matches[i].Groups[1].Captures[0].Value ?? string.Empty;
        if (pigTrans.Length > 1) {
            pigTrans = pigTrans.Substring(1) + pigTrans.Substring(0, 1) + "ay";
        }
        result.Append(pigTrans).Append(matches[i].Groups[2].Captures[0].Value);
    }
    return result.ToString();
}
The matches variable should contain all the match collections of 2 groups.  The first group will be 0 or more letters to translate followed by a second group of 0 or more non-letters to pass through. The StringBuilder should be more memory efficient than concatenating System.String values.  I gave it a starting allocation of double the initial string size just to avoid having to double the allocated space.  If memory is tight, maybe 1.25 or 1.5 instead of 2 would be better, but you'd probably have to convert it back to int after. I took the length calculation off your Substring call because leaving it out grabs everything to the end of the string already.
