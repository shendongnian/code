    string example =
        "This is an example of a paragraph! It contains three sentences? And the average sentence has many words.";
    var splitExample = example.Split(new[] {'.', '!', '?'}, StringSplitOptions.RemoveEmptyEntries);
    var matchExpression = new Regex("three");
    double avgLength = splitExample.Average(x => x.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Length);
    int sentences = splitExample.Length;
    int matches = splitExample.Where(x => matchExpression.IsMatch(x)).Count();
