    // constructor
    public Word(string title, Dictionary<string, string> categorizedDefinition)
    {
        // ignoring title for now, because it already works.
        this._categorizedDefinition = categorizedDefinition
            ?? throw new ArgumentNullException(nameof(categorizedDefinition));
    }
    private Dictionary<string, string> _categorizedDefinition
    public Dictionary<string, string> CategorizedDefinition
    {
        get =>  _categorizedDefinition;
    }
