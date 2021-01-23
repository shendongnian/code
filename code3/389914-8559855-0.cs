    string listOfWords = "Some, text, to, look, through";
    
    if (WordExists(listOfWords, "look"))
    {
    
    }
    private bool WordExists(string listToCheck, string wordToFind)
    {
       return listToCheck.Contains(wordToFind);
    }
