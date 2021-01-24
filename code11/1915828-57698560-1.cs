    // First change name to represent what you actually wanna do
    public static string GetRandomParagraph(string fileName)
    {
        /* 
           Rather than reading all the lines, read all the text
           this gives you the flexibility to split by line and paragraph
        */
        var allText = File.ReadAllText(fileName);
        // do a split to get the lines
        var lines = allText.Split("\r\n");
        // get a random number
        var lineNumber = _rand.Next(0, lines.Length);
        // get a line as a search value
        var searchValue = lines[lineNumber];
        // split all the text into paragraphs
        var paragraphs = allText.Split("\r\n\r\n");
        // search the paragraphs for the random 'searchValue' line
        var reply = paragraphs.First(x => x.Contains(searchValue));
            
        // return the paragraph    
        return reply;
    }
