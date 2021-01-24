    static IEnumerable<TestCaseData> TestData()
    {
        var reader = new StreamReader(File.OpenRead(
            @"C:\Test\MultiplicationZero.txt"));
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(',');
            // Assume there are exactly two items, and they are ints
            // If there are less than two or format is incorrect, then
            // you'll get an exception and have to fix the file. 
            // Otherwise add error handling.
            int lhs = Int32.Parse(values[0])
            int rhs = Int32.Parse(values[1]);
            yield return new TestCaseData(lhs, rhs);
        }
    }
