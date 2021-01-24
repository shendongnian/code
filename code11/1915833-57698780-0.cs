    // This builds a list of Paragraph first
    public static List<string> GetParagraphs(string filename)
    {        
        var paragraphs = new List<string>();
        var lines = File.ReadAllLines(filename);
        bool newParagraph = true;
        string CurrentParagraph = string.Empty;
        // Build the list of paragraphs by adding to the currentParagraph until empty lines and then starting a new one
        foreach(var line in lines)
        {
            if(newParagraph)
            {
                CurrentParagraph = line;
                newParagraph = false;
            }
            else
            {
                if(string.IsNullOrWhiteSpace(line))// we're starting a new paragraph, add it to the list of paragraphs and reset current paragraph for next one
                {
                    paragraphs.Add(CurrentParagraph);
                    CurrentParagraph = string.Empty;
                    newParagraph = true;
                }
                else // we're still in the same paragraph, add the line to current paragraph
                {
                    newParagraph += (Environment.NewLine + line);
                }
            }
        }
        // Careful, if your file doesn't end with a newline the last paragraph won't count as one, in that case add it manually here.
    }
    public static Random rnd = new Random();
    // And this returns a random one
    public static string GetRandomParagraph(string fileName)
    {
         var allParagraphs = GetParagraphs(filename);
         allParagraphs[rnd.Next(0,allParagraphs.length-1)]; // pick one of the paragraphs at random, stop at length-1 as collection indexers are 0 based    
    }
