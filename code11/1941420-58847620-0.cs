    /// Runs like a pipe: passing the text through several stages of subprocesses
    public string Process(string country, string text)
    {
        text = Capitalise(country, text);
        text = RemovePunctuation(country, text);
        // And so on and so forth...
        return text;
    }
    private string Capitalise(string country, string text)
    {
        if ( ! CapitaliseApplicableCountries.ContainsKey(country) )
        {
            /* skip */
            return text;
        }
    
        /* do the capitalisation */
        return capitalisedText;
    }
    
    private string RemovePunctuation(string country, string text)
    {
        if ( ! RemovePunctuationApplicableCountries.ContainsKey(country) )
        {
            /* skip */
            return text;
        }
    
        /* do the punctuation removal */
        return punctuationFreeText;
    }
    
    private string Replace(string country, string text)
    {
        // Implement it following the pattern demonstrated earlier.
    }
