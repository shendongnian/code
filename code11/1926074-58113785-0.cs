    string s = "Month04";
    Regex pattern = new Regex(@"\d+");
    var numbersInString = pattern.Matches(s).Cast<Match>().Select(x = int.Parse(x.Value));
    int lowerBound = 4;
    int upperBound = 11;
    var range = Enumerable.Range(lowerBound, upperBound - lowerBound + 1);
    if (numbersInString.Intersect(range).Any())
    {
        //Match
    }
