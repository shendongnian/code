    private char _nextChar;
    private IList<char> getAlphabet()
    {
        return Array.AsReadOnly(new[] { 'A', 'B', 'C' });
    }
    
    public void sortAlphabet()
    {
        IList<char> alphabet = getAlphabet();
        for (int i = 0; i < alphabet.Count - 1; ++i)
        {
            char alpha = alphabet[i];
            switch (alpha)
            {
                case 'A':
                    _nextChar = alphabet[i + 1];
                    break;
                case 'B':
                    // etc.
                    break;
            }
        }
    }
