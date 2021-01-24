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
