    public static string RemoveWord(string input, string wordToRemove)
    {
        // Validate aruguments, and exit early if they're null or empty
        if (string.IsNullOrEmpty(input)) return input;
        if (string.IsNullOrEmpty(wordToRemove)) return input;
        string currentWord = "";  // This will hold the current word that we're building
        string result = "";       // This will hold the string we return to the caller
        // Examine each character in the input string
        foreach (char chr in input)
        {
            // If the character is a space, then...
            if (chr == ' ')
            {
                // If the word we've captured is not the word to remove, add it to result
                if (currentWord != wordToRemove)
                {
                    result += currentWord + chr;
                }
                
                // Reset our word to an empty string since we've added or ignored it now
                currentWord = "";
            }
            // If the character is NOT a space, then...
            else
            {
                // Add this character to the word we're building
                currentWord += chr;
            }
        }
        // When we reach the end, do one more check in case there's a word remaining
        if (currentWord != wordToRemove)
        {
            result += currentWord;
        }
        // Return the input (without the wordToRemove) to the caller
        return result;
    }
