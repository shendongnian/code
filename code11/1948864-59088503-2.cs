    string input = "ababab";
    Regex regx = new Regex("a", RegexOptions.IgnoreCase);
    MatchCollection myMatches = regx.Matches(input);
    Match lastMatch = myMatches.OfType<Match>().Last();
    string result = input.Substring(lastMatch.Index, lastMatch.Length); // ababab
                                                                        //     ^
