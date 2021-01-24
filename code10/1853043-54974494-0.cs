    // define value delimiters.
    var splitChars = new char[] { ' ', ':' };
    // read lines and parse into enumerable of enumerable of ints.
    var lines = File.ReadAllLines(txtPath.Text)
        .Select(x => x.Split(splitChars)
            .Select(int.Parse));
    // search in array.
    var occurences = lines
        .Select((line,lineIndex) => line
            .Select((integer, integerIndex) => new { integer, integerIndex })
            .Where(x => x.integer == 10)
            .Select(x => x.integerIndex));
    // calculate all of array.
    var total = lines.Sum(line => line.Sum());
