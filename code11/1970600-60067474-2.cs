    void IterateTable(Dictionary<int,Animal> dictionary)
    {
        dictionary.Add(1, new Boar()); //This would fail if you'd passed in a dictionary of Lions
        dictionary.Add(2, new Lion()); //This would fail if you'd passed in a dictionary of Boars
    }
