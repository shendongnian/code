    public bool IsFull
    {
        get { return this.Bananas.Count > 5; }
    }
    public bool ContainsBanana(string name)
    {
        return this.Bananas.Any(b => b.Name == name);
    }
