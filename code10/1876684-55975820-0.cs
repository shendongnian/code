Match[] matches = Regex.Matches(str, @"([a-zA-Z]*)([^a-zA-Z]*)").Cast<Match>().Select(m => m.Value).ToArray();
StringBuilder result = new StringBuilder();
for (int i = 0; i < matches.Length; ++i) {
  // Assign matches[i].Groups[1].Captures[0] to the pigTrans variable in your code.
  // Perform your pigTrans manipulations if pigTrans is not String.Empty.
  // Append pigTrans to result.
  // Append matches[i].Groups[2].Captures[0] to result.
}
