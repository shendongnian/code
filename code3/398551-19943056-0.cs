    static void Main(string[] args)
    {
        Debug.Assert(CountWords("Hello world") == 2);
        Debug.Assert(CountWords("    Hello world") == 2);
        Debug.Assert(CountWords("Hello world    ") == 2);
        Debug.Assert(CountWords("Hello      world") == 2);
    }
    public static int CountWords(string test)
    {
        int count = 0;
        bool wasInWord = false;
        bool inWord = false;
    
        for (int i = 0; i < test.Length; i++)
        {
            if (inWord)
            {
                wasInWord = true;
            }
    
            if (Char.IsWhiteSpace(test[i]))
            {
                if (wasInWord)
                {
                    count++;
                    wasInWord = false;
                }
                inWord = false;
            }
            else
            {
                inWord = true;
            }
        }
    
        // Check to see if we got out with seeing a word
        if (wasInWord)
        {
            count++;
        }
    
        return count;
    }
