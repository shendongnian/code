       public static List<Word> GetWords(string sourceText, char[] delimiters = null)
                {
                    // initial value
                    List<Word> words = new List<Word>();
    
                    // typical delimiter characters
                    char[] delimiterChars = { ' ', '-', '/', ',', '.', ':', '\t' };
    
                    // if the delimiters exists
                    if (delimiters != null)
                    {
                        // use the delimiters passedin
                        delimiterChars = delimiters;
                    }
    
                    // verify the sourceText exists
                    if (!String.IsNullOrEmpty(sourceText))
                    {
                        // Get the list of strings
                        string[] strings = sourceText.Split(delimiterChars);
    
                        // now iterate the strings
                        foreach (string stringWord in strings)
                        {
                            // verify the word is not an empty string or a space
                            if (!String.IsNullOrEmpty(stringWord))
                            {
                                // Create a new Word
                                Word word = new Word(stringWord);
    
                                // now add this word to words collection
                                words.Add(word);
                            }
                        }
                    }
    
                    // return value
                    return words;
                }
