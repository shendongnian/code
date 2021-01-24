    var searchTerm = "Hello";
    var fileList = new List<string>() { "A.txt", "B.txt", "C.txt" };
    var resultList = new List<SearchResults>();
    // Iterate through files. You already are doing this.
    foreach (var file in fileList)
    {
        // Check to see if file exists. This is a second line of defense in error checking, not really necessary but good to have.
        if (File.Exists(file))
        {
            // Read all lines in the file into an array of strings.
            var lines = File.ReadAllLines(file);
            // In this file, extract the lines contain the keyword
            var foundLines = lines.Where(x => x.Contains(searchTerm));
            if (foundLines.Count() > 0)
            {
                var count = 0;
                // Iterate each line that contains the keyword at least once to see how many times the word appear in each line
                foreach (var line in foundLines)
                {
                    // The CountSubstring helper method counts the number of occurrences of a string in a string.
                    var occurences = CountSubstring(line, searchTerm);
                    count += occurences;
                }
                // Add the result to the result list.
                resultList.Add(new SearchResults() { FilePath = file, Occurences = count, SearchWord = searchTerm });
            }
        }
    }
