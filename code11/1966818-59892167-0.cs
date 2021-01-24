    public List<THE_TYPE>() Characters = new List<THE_TYPE>();
    void GenerateCharacter()
    {
        // now everytime you generate a new character add it to the list e.g.
        var newChar = Instantiate(...);
        Characters.Add(newChar.GetComponent<THE_TYPE>());
    }
