    public void AddWord ()
    {
        WordGenerator.NewRandomIndex();
        
        Word word = new Word(WordGenerator.GetWord_Romaji(), wordSpawner.SpawnWord());
        words.Add (word);
    }
    
