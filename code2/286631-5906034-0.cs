    public PolyAnalyzer()
    {
        Dictionaries = new Dictionary<string, AbstractDictionary>();
        Dictionaries.Add("Bulgarian", new BulgarianDictionary());
        Dictionaries.Add("English", new EnglishDictionary());
        Dictionaries.Add("German", new GermanDictionary());
    
        //Tip: Use the Parallel library to to multi-core, multi-threaded work.
        Parallel.ForEach(Dictionaries.Values, d =>
        {
            d.LoadDictionaryAsync();
        });            
    }  
    
    public Dictionary<string, int> GetResults(string text)
    {
        //1) Split the words.
        //2) Calculate the score per dictionary (per language).
        //3) Return the scores.
        string[] words = new Regex(@"\w+").Split().ToArray();
        Dictionary<string, int> scores = this.Dictionaries.Select(d => new
        {
            Language = d.Key,
            Score = words.Sum(w => d.Value.GetScore(w))
        }));
    
        return scores;
    }
