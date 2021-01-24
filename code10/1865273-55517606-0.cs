    static readonly char[] separatorChars = new char[] {','}
    const string questionMark = "?";
    static readonly IEqualityComparer<string> comparer = 
    var rowsWithoutQuestionMarkValues = userData
        // Split each line into column values, using comma as separator
        .Select(line => line.Split(separatorChar)
        // do not use the line if any of the columns equals the question mark
        .Where(splitLine => !splitLine.Any(column => column == questionMark));
