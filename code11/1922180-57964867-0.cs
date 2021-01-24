    var sentence = "now is the time for all good men to come, to the aid of their country.";
    var words = new[] { "time", "to" };
    
    var wordsHS = words.ToHashSet();
    var wordRE = new Regex(@"\w+", RegexOptions.Compiled);
    var wordCounts = wordRE.Matches(sentence).Cast<Match>().Select(m => m.Value)
                           .Where(w => wordsHS.Contains(w))
                           .GroupBy(w => w)
                           .Select(wg => new { Word = wg.Key, Count = wg.Count() })
                           .ToList();
    var total = wordCounts.Sum(wc => wc.Count);
